using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject storyText;



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
    }

    //�^�C�g����ʂŎg�p
    public void OnClickStartButton()
    {
        StartCoroutine(StartButton());
        
    }

    IEnumerator StartButton()
    {
        startButton.SetActive(false);
        title.SetActive(false);
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
        Application.Quit();
        Debug.Log("Exit");
    }

    //�Q�[���I�[�o�[��ʂŎg�p
    public void OnClickContinueButton()
    {
        if(stageNum == 1)
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

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
        CheckPointScript.m_nowCheckpoint = 0;
        stageNum = 0;
        PlayerBulletManagerScript.bulletNum = 0;
        BossCheckPointScript.m_BossCheckpoint = 0;
    }

    //�Q�[����ʂŎg�p
    public void PlayerDie()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ToGate()
    {
        SceneManager.LoadScene("Boss_1Scene");
    }

    //Boss1�Ŏg�p
    public void ToBoss2()
    {
        SceneManager.LoadScene("Boss_2Scene");
    }

    //Boss2�Ŏg�p
    public void ToClear()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
