using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianScript : EnemyAdstract
{
    [SerializeField] AudioSource damageSE_Sou;
    [SerializeField] AudioClip damageSE_Cli;

    [SerializeField] AudioSource dedSE_Sou;
    [SerializeField] AudioClip ded_Cli;

    [SerializeField] AudioSource attackSE_Sou;
    [SerializeField] AudioClip attackSE_Cli;

    [SerializeField] AudioSource warpSE_Sou;
    [SerializeField] AudioClip warpSE_Cli;


    [SerializeField] float magicianHp;

    [SerializeField] int magicianPower;

    [SerializeField] bool magicianDed;

    [SerializeField] bool doTeleport;

    [SerializeField] float teleportCoolTime;

    [SerializeField] GameObject player;

    [SerializeField] GameObject rSensor;

    [SerializeField] GameObject lSensor;

    [SerializeField] private int randNum;


    [SerializeField] Vector3 toPlayerDistance;

    // Start is called before the first frame update
    void Start()
    {
        rSensor = GameObject.Find("MagicianRSensor");

        lSensor = GameObject.Find("MagicianLSensor");

        doTeleport = true;

        player = GameObject.Find("WizardVariant");

        gameObject.transform.position += new Vector3(0, 2, 0);

        gameObject.GetComponent<Animator>().SetTrigger("bron");
    }

    // Update is called once per frame
    void Update()
    {
        if (!magicianDed)
        {
            toPlayerDistance = player.transform.position - gameObject.transform.position;



            if (toPlayerDistance.x < 0)
            {
                gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            if (0 < toPlayerDistance.x)
            {
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            if (0 >= magicianHp)
            {
                dead();
            }

            if (50 <= Mathf.Abs(toPlayerDistance.x))
            {
                Destroy(gameObject);
            }


            if (doTeleport)
            {
                StartCoroutine(TeleportTime());
            }
            

        }
    }

    void Hurt(float bulletPower)
    {
        damageSE_Sou.PlayOneShot(damageSE_Cli);
        gameObject.GetComponent<Animator>().SetTrigger("hurt");
        magicianHp -= bulletPower;
    }


    public void Attack()
    {
        gameObject.GetComponent<Animator>().SetTrigger("attack");
        StartCoroutine(AttackTime());
    }


    void dead()
    {
        dedSE_Sou.PlayOneShot(ded_Cli);
        magicianDed = true;
        gameObject.GetComponent<Animator>().SetTrigger("ded");
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(DethTime());
    }

    void TeleportMain()
    {
        warpSE_Sou.PlayOneShot(warpSE_Cli);

        randNum = Random.Range(1, 2 + 1);

        switch(randNum)
        {
            case 1:
                if(!rSensor.GetComponent<MagicianSensorScript>().GetOnObj())
                {
                    Teleport(rSensor);
                }
                else if(!lSensor.GetComponent<MagicianSensorScript>().GetOnObj())
                {
                    Teleport(lSensor);
                }
                else
                {
                    return;
                }
                break;

            case 2:
                if (!lSensor.GetComponent<MagicianSensorScript>().GetOnObj())
                {
                    Teleport(lSensor);
                }
                else if (!rSensor.GetComponent<MagicianSensorScript>().GetOnObj())
                {
                    Teleport(rSensor);
                }
                else
                {
                    return;
                }
                break;

            default:
                return;
        }
    }

    void Teleport( GameObject obj)
    {
        gameObject.transform.position = obj.transform.position;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("bron");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet" || collision.tag == "VehicleBullet")
        {
            Hurt(collision.GetComponent<PlayerBulletAdstract>().GetBulletPower());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Map" || collision.tag == "VehicleBullet")
        {
            dead();
        }
    }


    IEnumerator DethTime()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    IEnumerator AttackTime()
    {
        attackSE_Sou.PlayOneShot(attackSE_Cli);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(1.1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        attackSE_Sou.Stop();
    }

    IEnumerator TeleportTime()
    {
        
        doTeleport = false;
        yield return new WaitForSeconds(teleportCoolTime);

        TeleportMain();

        yield return new WaitForSeconds(0.5f);

        Attack();
 
        doTeleport = true;
    }

    public override int GetEnemyPower()
    {
        return magicianPower;
    }
}
