using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChestGoldScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject Iteme;

    [SerializeField]
    List<GameObject> ItemeList;


    [SerializeField] int randNum;

    private Animator chestAnim;

    private BoxCollider2D chestDollider2D;

    [SerializeField] float generationTime;

    bool doClose;

    public float aa;

    void Update()
    {
        if(doClose)
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) >= 3
                || Mathf.Abs(player.transform.position.y - transform.position.y) >= 3)
            {
                doClose = false;
                chestAnim.SetTrigger("Close");
                chestDollider2D.enabled = true;
            }
           
        }
    }

    private void Start()
    {
        
        chestAnim = GetComponent<Animator>();
        chestDollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PlayerBullet" || collision.tag == "VehicleBullet")
        {
            chestAnim.SetTrigger("Open");
            chestDollider2D.enabled = false;

            if (Iteme != null)
            {
                StartCoroutine(ItemGenerationTime(Iteme));
                if (SceneManager.GetActiveScene().name == "Boss_1Scene")
                {
                    StartCoroutine(Close());
                }
                
            }
            else if (ItemeList[0] != null)
            {
                randNum = Random.Range(0, ItemeList.Count);
                StartCoroutine(ItemGenerationTime(ItemeList[randNum]));
                if (SceneManager.GetActiveScene().name == "Boss_1Scene")
                {
                    StartCoroutine(Close());
                }

            }
            else
            {
                return;
            }
        }
    }



    IEnumerator ItemGenerationTime(GameObject GeneratObj)
    {
        yield return new WaitForSeconds(generationTime);
        Instantiate(GeneratObj).transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, 0);
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(5);
        doClose = true;
    }

}
