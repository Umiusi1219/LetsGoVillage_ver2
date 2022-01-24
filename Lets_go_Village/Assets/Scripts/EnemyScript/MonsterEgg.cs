using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterEgg : MonoBehaviour
{
    [SerializeField] private float generationCoolTime;

    [SerializeField] private int randNum;

    [SerializeField] private bool generationPossible = true;

    [SerializeField] GameObject generationMonster;

    [SerializeField] List<GameObject> generationMonsterList;

    [SerializeField] GameObject boss;


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Boss_2Scene")
        {
            if (boss == null && gameObject.GetComponent<CapsuleCollider2D>().enabled == true)
            {
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (generationPossible && collision.tag == "Player")
        {
            if (generationMonster != null)
            {
                Instantiate(generationMonster).transform.position = gameObject.transform.position;
            }
            else if (generationMonsterList[0] != null)
            {
                randNum = Random.Range(0, generationMonsterList.Count);
                Instantiate(generationMonsterList[randNum])
                .transform.position = gameObject.transform.position;
            }
            else
            {
                return;
            }

            generationPossible = false;

            StartCoroutine(MonsterGenerationCoolTime());
        }
    }


    IEnumerator MonsterGenerationCoolTime()
    {
        yield return new WaitForSeconds(generationCoolTime);

        generationPossible = true;
    }
}
