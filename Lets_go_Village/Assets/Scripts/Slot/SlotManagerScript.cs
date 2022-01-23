using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManagerScript : MonoBehaviour
{
    [SerializeField] GameObject slotR;
    [SerializeField] GameObject slotS;
    [SerializeField] GameObject slotL;

    [SerializeField] public bool m_stopFirstSlot;
    [SerializeField] public int m_slotNum;
    [SerializeField] float[] slotPower;
    [SerializeField] bool doAttack;

    [SerializeField] GameObject bossEnemy;
    // Start is called before the first frame update
    void Start()
    {
        m_stopFirstSlot = false;
        doAttack = true;
        m_slotNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (slotR.GetComponent<SlotScript>().m_Stop && slotS.GetComponent<SlotScript>().m_Stop
            && slotL.GetComponent<SlotScript>().m_Stop)
        {
            if(doAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }

    void SlotReset()
    {
        m_stopFirstSlot = false;
        m_slotNum = 0;

        slotR.GetComponent<SlotScript>().SlotReset();
        slotS.GetComponent<SlotScript>().SlotReset();
        slotL.GetComponent<SlotScript>().SlotReset();
    }

    IEnumerator Attack()
    {
        doAttack = false;
        yield return new WaitForSeconds(1f);
        bossEnemy.GetComponent<BossEnemyScript>().Hurt(slotPower[m_slotNum - 1]);
        SlotReset();
        doAttack = true;
    }
}
