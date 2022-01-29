using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [SerializeField] int checkPointNum;

    [SerializeField] int effectDirection;

    [SerializeField] public static int m_nowCheckpoint;

    [SerializeField] private bool isFirst;

    [SerializeField] GameObject effect;

    private void Start()
    {
        isFirst = true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFirst && collision.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            m_nowCheckpoint = checkPointNum;
            if (isFirst)
            {
                Instantiate(effect).transform.position = new Vector3(transform.position.x - (0.3f* effectDirection),
                    transform.position.y + 2.2f, 0);
            }
            isFirst = false;
        }
    }
}

