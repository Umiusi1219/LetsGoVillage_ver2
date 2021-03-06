using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : EnemyAdstract
{
    [SerializeField] AudioSource damageSE_Sou;
    [SerializeField] AudioClip damageSE_Cli;

    [SerializeField] AudioSource dedSE_Sou;
    [SerializeField] AudioClip ded_Cli;

    [SerializeField] AudioSource attackSE_Sou;
    [SerializeField] AudioClip attackSE_Cli;


    [SerializeField] float archerHp;

    [SerializeField] float shootCoolTime;

    [SerializeField] float doAttackRange;

    [SerializeField] int archerPower;

    [SerializeField] bool archerDed;

    [SerializeField] bool doShoot;

    [SerializeField] GameObject shootObj;

    [SerializeField] GameObject player;

    [SerializeField] float toPlayerDistance;

    // Start is called before the first frame update
    void Start()
    {
        doShoot = true;

        player = GameObject.Find("WizardVariant");

        gameObject.transform.position += new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!archerDed)
        {
            toPlayerDistance = player.transform.position.x - gameObject.transform.position.x;

            if (toPlayerDistance < 0)
            {
                gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            if (0 < toPlayerDistance)
            {
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            if (0 >= archerHp)
            {
                dead();
            }

            if (50 <= Mathf.Abs(toPlayerDistance))
            {
                Destroy(gameObject);
            }

            if (doAttackRange > Mathf.Abs(toPlayerDistance) && doShoot)
            {
                Attack();
            }
        }
    }

    void Hurt(float bulletPower)
    {
        damageSE_Sou.PlayOneShot(damageSE_Cli);
        gameObject.GetComponent<Animator>().SetTrigger("hurt");
        archerHp -= bulletPower;
    }


    public void Attack()
    {
        gameObject.GetComponent<Animator>().SetTrigger("shoot");
        StartCoroutine(AttackTime());
    }


    void dead()
    {
        dedSE_Sou.PlayOneShot(ded_Cli);
        archerDed = true;
        gameObject.GetComponent<Animator>().SetTrigger("ded");
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(DethTime());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet" || collision.tag == "VehicleBullet")
        {
            Hurt(collision.GetComponent<PlayerBulletAdstract>().GetBulletPower());
        }
    }

    IEnumerator DethTime()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    IEnumerator AttackTime()
    {
        doShoot = false;
        yield return new WaitForSeconds(0.4f);

        attackSE_Sou.PlayOneShot(attackSE_Cli);
        Instantiate(shootObj).transform.position = gameObject.transform.position;
        
        yield return new WaitForSeconds(shootCoolTime);
        doShoot = true;
    }



    public override int GetEnemyPower()
    {
        return archerPower;
    }
}
