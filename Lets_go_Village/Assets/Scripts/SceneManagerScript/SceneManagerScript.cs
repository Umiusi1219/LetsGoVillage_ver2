using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

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
    public void ToBoss3()
    {
        SceneManager.LoadScene("Boss_3Scene");
    }


}
