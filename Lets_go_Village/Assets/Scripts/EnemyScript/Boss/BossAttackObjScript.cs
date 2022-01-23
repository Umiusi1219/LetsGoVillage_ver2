using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackObjScript : EnemyAdstract
{
    [SerializeField] int bossPower;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 EndPos;
    [SerializeField] Vector3 moveDistance;
    [SerializeField] public bool m_DoAttack;
    [SerializeField] float moveSecond;
    [SerializeField] GameObject boss;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
        m_DoAttack = false;

        moveDistance.x = EndPos.x - startPos.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(boss.GetComponent<BossEnemyScript>().m_BossHp > 0)
        {
            if (moveDistance.x > 0)
            {
                if (m_DoAttack && transform.position.x <= EndPos.x)
                {
                    gameObject.transform.position += new Vector3((moveDistance.x)
                        / (60 * moveSecond), 0, 0);
                }
                else if (transform.position.x >= (EndPos.x - 5))
                {
                    transform.position = startPos;
                    m_DoAttack = false;
                }
            }
            else if ((moveDistance.x < 0))
            {
                if (m_DoAttack && transform.position.x >= EndPos.x)
                {
                    gameObject.transform.position += new Vector3((moveDistance.x)
                        / (60 * moveSecond), 0, 0);
                }
                else if (transform.position.x <= (EndPos.x + 5))
                {
                    transform.position = startPos;
                    m_DoAttack = false;
                }
            }
        }
       
    }



    public IEnumerator Hurt()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
    }

    public override int GetEnemyPower()
    {
        return bossPower;
    }
}
