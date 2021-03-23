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
        light = gameObject.GetComponent<Light2D>();
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
        light.enabled = isOn;
        NotifyTaskManager(GetTaskName(), isOn);
    }


    private Light2D light;

    public bool isOn;

    private Animator anim;
}
