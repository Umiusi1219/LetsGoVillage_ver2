using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadScript : EnemyAdstract
{

    [SerializeField] AudioSource dedSE_Sou;
    [SerializeField] AudioClip ded_Cli;

    [SerializeField] AudioSource attackSE_Sou;
    [SerializeField] AudioClip attackSE_Cli;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float undeadMovePower;

    [SerializeField]
    private int undeadPower;

    [SerializeField]
    float toPlayerDistance;

    private int undeadDirection = 1;

    bool undeadDed = false;

    [SerializeField] Vector3 bronPosAdd;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position += bronPosAdd;

        player = GameObject.Find("WizardVariant");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!undeadDed)
        {
            toPlayerDistance = player.transform.position.x - gameObject.transform.position.x;
            Run();
            if (50 <= Mathf.Abs(toPlayerDistance))
            {
                Destroy(gameObject);
            }
        }
    }

    void Run()
    {

        Vector3 moveVelocity = Vector3.zero;

        if (toPlayerDistance < -0.5f)
        {
            undeadDirection = -1;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(undeadDirection, 1, 1);

        }
        if (0.5f < toPlayerDistance)
        {
            undeadDirection = 1;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(undeadDirection, 1, 1);
        }
        transform.position += moveVelocity * undeadMovePower * Time.deltaTime;

    }

    void dead()
    {
        gameObject.GetComponent<Animator>().SetBool("ded", true);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(DethTime());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet" || collision.tag == "VehicleBullet")
        {
            undeadDed = true;

            dead();
        }
    }



    IEnumerator DethTime()
    {
        dedSE_Sou.PlayOneShot(ded_Cli);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject.transform.parent.gameObject);
    }


    public override int GetEnemyPower()
    {
        attackSE_Sou.PlayOneShot(attackSE_Cli);

        return undeadPower;
    }
}
