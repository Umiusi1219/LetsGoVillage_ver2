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

    //タイトル画面で使用
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickExitButtom()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    //ゲームオーバー画面で使用
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

    //ゲーム画面で使用
    public void PlayerDie()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ToGate()
    {
        SceneManager.LoadScene("Boss_1Scene");
    }

    //Boss1で使用
    public void ToBoss2()
    {
        SceneManager.LoadScene("Boss_2Scene");
    }

    //Boss2で使用
    public void ToBoss3()
    {
        SceneManager.LoadScene("Boss_3Scene");
    }


}
