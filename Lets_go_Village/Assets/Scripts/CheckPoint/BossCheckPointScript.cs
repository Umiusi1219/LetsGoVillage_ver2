using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckPointScript : MonoBehaviour
{
    [SerializeField] int checkPointNum;

    [SerializeField] public static int m_BossCheckpoint;

    [SerializeField] private bool isFirst;

    [SerializeField] GameObject effect;

    private void Start()
    {
        isFirst = true;

        Debug.Log(m_BossCheckpoint);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirst && collision.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            m_BossCheckpoint = checkPointNum;
            if (isFirst)
            {
                Instantiate(effect).transform.position = new Vector3(transform.position.x+ 0.3f,
                    transform.position.y + 2.4f, 0);
            }
            isFirst = false;
        }
    }
}
