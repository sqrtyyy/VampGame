using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Photon.Pun;

public class TorchTask : ITask
{
    private PhotonView photonView;

    void Awake()
    {
        photonView = PhotonView.Get(this);
        AddTaskManager(TaskManager.Instance());

        anim = GetComponent<Animator>();
        ChangeStatus();
    }

    public override void StartTask()
    {
        AsyncStartTask();
        photonView.RPC("AsyncStartTask", RpcTarget.Others);
    }

    [PunRPC]
    private void AsyncStartTask()
    {
        if (!IsCompleted())
        {
            isOn = true;
            ChangeStatus();
        }
    }

    public override void SabotageTask()
    {
        AsyncSabotageTask();
        photonView.RPC("AsyncSabotageTask", RpcTarget.Others);
    }

    [PunRPC]
    private void AsyncSabotageTask()
    {
        if (IsCompleted())
        {
            isOn = false;
            ChangeStatus();
        }
    }


    public override string GetTaskName()
    {
        return "Зажечь факела";
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
