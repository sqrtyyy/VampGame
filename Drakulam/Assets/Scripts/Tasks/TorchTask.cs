using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchTask : ITask
{

    void Start()
    {
        AddTaskManager(TaskManager.Instance());

        anim = GetComponent<Animator>();
        ChangeStatus();
    }

    public override void StartTask()
    {
        if (!IsCompleted())
        {
            isOn = true;
            ChangeStatus();
        }
    }

    public override void SabotageTask()
    {
        if (IsCompleted())
        {
            isOn = false;
            ChangeStatus();
        }
    }


    public override string GetTaskName()
    {
        return "Зажгите факела";
    }


    public override bool IsCompleted()
    {
        return isOn;
    }


    private void ChangeStatus()
    {
        anim.SetBool("isOn", isOn);
        ChangeLightStatus(isOn);
        NotifyTaskManager(GetTaskName(), isOn);
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
