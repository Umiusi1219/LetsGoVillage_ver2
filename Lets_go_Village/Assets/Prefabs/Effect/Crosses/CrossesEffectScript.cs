using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossesEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetTrigger("OnEffect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
