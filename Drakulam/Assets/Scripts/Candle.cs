using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Candle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeStatus()
    {
        anim.SetBool("isOn", isOn);
        ChangeLightStatus(isOn);
    }

    private void ChangeLightStatus(bool status)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Light2D>().enabled = status;
        }
    }

    public bool isOn;

    private Animator anim;
}
