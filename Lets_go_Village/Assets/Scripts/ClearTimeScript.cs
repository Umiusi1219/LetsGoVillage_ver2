using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTimeScript : MonoBehaviour
{
    Text clearTime;

    float minute;

    float second;

    // Start is called before the first frame update
    void Start()
    {
        clearTime = gameObject.GetComponent<Text>();

        minute = SceneManagerScript.clearTime / 60;
        second = SceneManagerScript.clearTime % 60;

        clearTime.text = "Clear Time    " + minute.ToString("F0") 
            + ":" + second.ToString("F0");
    }


}
