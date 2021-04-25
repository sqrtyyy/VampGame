using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Photon.Pun;
using Utils;

public class TorchTask : ITask
{
    private PhotonView photonView;

    void Awake()
    {
        photonView = PhotonView.Get(this);
        AddTaskManager(TaskManager.Instance());

        anim = GetComponent<Animator>();
        ChangeStatus();
        
        var exclamationMarkName = "ExclamationMark";
        _exclamationMark = Functions.GetScriptOnChild<ExclamationMark>(this, exclamationMarkName);
        if (_exclamationMark == null)
        {
            Debug.Log("EXMARK exclamation mark script is null");
            return;
        }
            
        _exclamationMark.canBeSabotaged = true;
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
            _exclamationMark.ChangeStatus();
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
            _exclamationMark.ChangeStatus();
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

    public override void SetPlayerInfo(PlayerInfo playerInfo)
    {
        if (_exclamationMark != null)
            _exclamationMark.SetPlayerClass(playerInfo.characterClass);
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
            var component = child.gameObject.GetComponent<Light2D>();
            if (component != null)
                component.enabled = status;
        }
    }


    public bool isOn;

    private Animator anim;
    private ExclamationMark _exclamationMark;
}
