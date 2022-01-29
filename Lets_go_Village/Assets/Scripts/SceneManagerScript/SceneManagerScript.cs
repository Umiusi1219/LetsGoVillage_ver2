using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject exitButton;

    [SerializeField] GameObject nextStageButton;

    [SerializeField] GameObject storyText;

    [SerializeField] public static float clearTime;

    static bool nextStageTrriger = false;

    static int stageNum;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            
            stageNum = 1;
        }
        if (SceneManager.GetActiveScene().name == "Boss_1Scene")
        {
            
            stageNum = 2;
        }
        if (SceneManager.GetActiveScene().name == "Boss_2Scene")
        {
            
            stageNum = 3;
        }
        
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if(nextStageTrriger)
            {
                nextStageButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                nextStageButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "Boss_1Scene"
            || SceneManager.GetActiveScene().name == "Boss_2Scene")
        {
            clearTime += Time.deltaTime;
        }
    }

    //タイトル画面で使用
    public void OnClickStartButton()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(StartButton());
        
    }

    IEnumerator StartButton()
    {
        startButton.SetActive(false);
        title.SetActive(false);
        exitButton.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        storyText.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 1f);

        yield return new WaitForSeconds(4f);

        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        storyText.GetComponent<Text>().color = new Color(1, 1, 1, 1f);

        storyText.SetActive(false);

        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("GameScene");
    }



    public void OnClickExitButtom()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
        Debug.Log("Exit");
    }

    //ゲームオーバー画面で使用
    public void OnClickContinueButton()
    {
        GetComponent<AudioSource>().Play();
        nextStageTrriger = true;
        if (stageNum == 1)
        {
            SceneManager.LoadScene("GameScene");   
        }
        else if(stageNum == 2)
        {
            SceneManager.LoadScene("Boss_1Scene");
        }
        else if (stageNum == 3)
        {
            SceneManager.LoadScene("Boss_2Scene");
        }
    }


    public void OnClickNextStageButton()
    {
        nextStageTrriger = false;
        if (stageNum == 1)
        {
            SceneManager.LoadScene("Boss_1Scene");
        }
        else if (stageNum == 2)
        {
            SceneManager.LoadScene("Boss_2Scene");
        }
        else if (stageNum == 3)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }


    public void OnClickTitleButton()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("TitleScene");
        CheckPointScript.m_nowCheckpoint = 0;
        stageNum = 0;
        PlayerBulletManagerScript.bulletNum = 0;
        BossCheckPointScript.m_BossCheckpoint = 0;
        clearTime = 0;

        nextStageTrriger = false;
    }

    //ゲーム画面で使用
    public void PlayerDie()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ToGate()
    {
        SceneManager.LoadScene("Boss_1Scene");
        nextStageTrriger = false;
    }

    //Boss1で使用
    public void ToBoss2()
    {
        SceneManager.LoadScene("Boss_2Scene");
        nextStageTrriger = false;
    }

    //Boss2で使用
    public void ToClear()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
