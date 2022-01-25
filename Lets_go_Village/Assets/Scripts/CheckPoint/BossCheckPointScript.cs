using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckPointScript : MonoBehaviour
{
    [SerializeField] int checkPointNum;

    [SerializeField] public static int m_BossCheckpoint;

    [SerializeField] private bool isFirst;

    private void Start()
    {
        isFirst = true;

        Debug.Log(m_BossCheckpoint);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirst && collision.tag == "Player")
        {
            m_BossCheckpoint = checkPointNum;

            isFirst = false;
        }
    }
}
