using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLastScript : MonoBehaviour
{
    bool doFlashing = true;
    bool ded = false;


    [SerializeField] GameObject player;
    [SerializeField] GameObject sceneManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doFlashing && !ded)
        {
            StartCoroutine(Flashing());
        }

        if(!ded && gameObject.transform.position.x - player.transform.position.x <= 15)
        {
            gameObject.transform.position = new Vector3(
                player.transform.position.x + 15, gameObject.transform.position.y, 0);
        }
        
    }

    public void BossDed()
    {
        StartCoroutine(Ded());
    }

    IEnumerator Flashing()
    {
        doFlashing = false;
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 1f);
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.9f, 0.9f, 1f);

        doFlashing = true;
    }

    IEnumerator Ded()
    {
        ded = true;

        this.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.8f);
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.6f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.4f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.2f);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
        yield return new WaitForSeconds(0.3f);

        sceneManager.GetComponent<SceneManagerScript>().ToClear();

        Destroy(gameObject);
    }
}
