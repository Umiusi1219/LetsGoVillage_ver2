using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemyScript : MonoBehaviour
{
    [SerializeField] Vector3 startPos;

    public float m_BossHp;
    [SerializeField] float m_BossHpMAX;

    [SerializeField] int randNum;
    [SerializeField] int attackNum;
    [SerializeField] float attack_1_CoolTime;
    [SerializeField] bool doAttack_1;

    [SerializeField] float attack_2_CoolTime;
    [SerializeField] bool doAttack_2;

    [SerializeField] bool doUp;
    [SerializeField] bool doDown;
    [SerializeField] GameObject sceneManager;

    [SerializeField] GameObject attackObjR;
    [SerializeField] GameObject attackObjL;

    [SerializeField] GameObject BossHpUi;

    [SerializeField] GameObject BrackUI;
    bool doBrack;




    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;

        m_BossHpMAX = m_BossHp;
        doAttack_1 = true;
        doAttack_2 = true;
        doUp = false;
        doBrack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_BossHp <= 0)
        { 
            StartCoroutine(NextStage());
            if(doBrack)
            {
                BrackUI.transform.localScale += new Vector3(0.8f, 0.8f, 0f);
            }
        }
        else
        {
            if (doUp)
            {

                gameObject.transform.position += new Vector3(0, 0.5f, 0);
            }
            else if (doDown && transform.position.y >= startPos.y)
            {
                transform.position -= new Vector3(0, 0.5f, 0);
            }


            if (doAttack_1)
            {
                randNum = Random.Range(1, 3);
                if (randNum == 1)
                {
                    StartCoroutine(Attack_1R());
                }
                else if (randNum == 2)
                {
                    StartCoroutine(Attack_1L());
                }
            }

            if (doAttack_2)
            {
                StartCoroutine(Attack_2());
            }
        }
    }

    IEnumerator Attack_1R()
    {
        doAttack_1 = false;
        yield return new WaitForSeconds((attack_1_CoolTime - 2) / 3);
        yield return new WaitForSeconds((attack_1_CoolTime - 2) / 3);
        doUp = true;
        doDown = false;
        yield return new WaitForSeconds((attack_1_CoolTime-2) / 3);
        attackObjR.GetComponent<BossAttackObjScript>().m_DoAttack = true;
        yield return new WaitForSeconds(3.5f);
        doDown = true;
        doAttack_1 = true;
    }
    IEnumerator NextStage()
    {
        yield return new WaitForSeconds(2);
        doBrack = true;
        yield return new WaitForSeconds(5);
        sceneManager.GetComponent<SceneManagerScript>().ToBoss2();
    }

    IEnumerator Attack_1L()
    {
        doAttack_1 = false;
        yield return new WaitForSeconds((attack_1_CoolTime - 2) / 3);
        yield return new WaitForSeconds((attack_1_CoolTime - 2) / 3);
        doUp = true;
        doDown = false;
        yield return new WaitForSeconds((attack_1_CoolTime - 2) / 3);
        attackObjL.GetComponent<BossAttackObjScript>().m_DoAttack = true;
        yield return new WaitForSeconds(3.5f);
        doDown = true;
        doAttack_1 = true;
    }

    IEnumerator Attack_2()
    {
        doAttack_2 = false;
        yield return new WaitForSeconds(attack_2_CoolTime);

        doAttack_2 = true;
    }


    public void Hurt(float slotPower)
    {
        m_BossHp -= slotPower;
        StartCoroutine(Hurt());
    }

    IEnumerator Hurt()
    {
        StartCoroutine(attackObjR.GetComponent<BossAttackObjScript>().Hurt());
        StartCoroutine(attackObjL.GetComponent<BossAttackObjScript>().Hurt());

        this.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);

        BossHpUi.GetComponent<Slider>().value = m_BossHp / m_BossHpMAX;

        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "aaa")
        {
            doUp = false;
        }
    }
}
