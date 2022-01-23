using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManagerScript : MonoBehaviour
{
    public static int bulletNum = 0;

    [SerializeField]
    List<GameObject> playerBulletList;

    public GameObject m_PlayerBullet;
    public float m_HaveBulletCoolTime;


    private void Start()
    {
        //�f�t�H���g��Bullet��ݒ�
        SetPlayerBullet(bulletNum);
    }

    public void SetPlayerBullet(int num)
    {
        bulletNum = num;

        m_PlayerBullet = playerBulletList[num];

        m_HaveBulletCoolTime = m_PlayerBullet.GetComponent<PlayerBulletAdstract>().GetCooltime();
    }

}

