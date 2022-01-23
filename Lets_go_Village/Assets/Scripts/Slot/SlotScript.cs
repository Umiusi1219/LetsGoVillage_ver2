using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField] GameObject slotManager;

    [SerializeField] playerBulletType hitBulletType;

    [SerializeField] int slotNum;

    [SerializeField] int slotNumMax;

    [SerializeField] public bool m_HitBullet;

    [SerializeField] public bool m_Stop;

    [SerializeField] bool doSlot;

    [SerializeField] float rotationTime;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        slotNum = 1;
        doSlot = true;
        m_Stop = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!slotManager.GetComponent<SlotManagerScript>().m_stopFirstSlot)
        {
            if (!m_HitBullet)
            {

                if (doSlot)
                {
                    StartCoroutine(SlotTime());
                }
            }
            else if (m_HitBullet)
            {
                slotManager.GetComponent<SlotManagerScript>().m_slotNum = slotNum;
                slotManager.GetComponent<SlotManagerScript>().m_stopFirstSlot = true;
                m_Stop = true;
            }
        }
        else
        {
            if (!m_HitBullet)
            {

                if (doSlot)
                {
                    StartCoroutine(SlotTime());
                }
            }
            else if (slotNum != slotManager.GetComponent<SlotManagerScript>().m_slotNum)
            {
                if (doSlot)
                {
                    StartCoroutine(SlotTime());
                }
            }
            else if(m_HitBullet)
            {
                m_Stop = true;
            }
        }
    }

    public void SlotReset()
    {
        m_Stop = false;
        m_HitBullet = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet" || collision.tag == "VehicleBullet")
        {
            if (collision.GetComponent<PlayerBulletAdstract>().GetBulletType()
            == hitBulletType.ToString())
            {
                m_HitBullet = true;

            }
        }
    }

    IEnumerator SlotTime()
    {
        doSlot = false;

        yield return new WaitForSeconds(rotationTime);
        slotNum++;
        
        if(slotNumMax < slotNum )
        {
            slotNum = 1;
        }

        anim.SetTrigger(slotNum.ToString());
        doSlot = true;
    }
}
