using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGroundScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BossEnemy")
        {
            transform.parent.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
