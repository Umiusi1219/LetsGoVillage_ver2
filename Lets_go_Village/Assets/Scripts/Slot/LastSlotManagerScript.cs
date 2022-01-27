using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSlotManagerScript : MonoBehaviour
{
    [SerializeField] public bool m_stopFirstSlot;
    [SerializeField] public bool m_stopSlot;
    [SerializeField] public int m_slotNum;
    [SerializeField] public int m_SlotCount;
    [SerializeField] bool doAttack;

    [SerializeField] GameObject LastBossEnemy;
    // Start is called before the first frame update
    void Start()
    {
        m_stopFirstSlot = false;
        doAttack = true;
        m_slotNum = 0;
        m_stopSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_SlotCount >= 3) 
        {
            m_stopSlot = true;
            if (doAttack)
            {
                StartCoroutine(BossKill());
            }
        }
    }

    IEnumerator BossKill()
    {
        doAttack = false;
        yield return new WaitForSeconds(1f);
        LastBossEnemy.GetComponent<BossLastScript>().BossDed();
    }
}
