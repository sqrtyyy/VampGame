using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class VampireTaskDisabler : ITaskCompleter, IPunObservable
{
    public Transform center;

    public LayerMask taskMask;

    public float radius;

    private static float coolDown = 15;
    private static float prevSabotageTime = -15;
    
    private PhotonView photonView;

    public static float getPercents()
    {
        float curTime = Time.time;
        float deltaTime = curTime - prevSabotageTime;
        return coolDown < deltaTime ? 1 : deltaTime / coolDown;
    }

    public override void FindTask()
    {
        if (!photonView.IsMine) return;
        Collider2D task = Physics2D.OverlapCircle(center.position, radius, taskMask);
        if (task)
        {
            float curTime = Time.time;
            if (curTime - prevSabotageTime > coolDown)
            {
                Debug.Log("SABOTAGE!!!!!");
                prevSabotageTime = curTime;
                task.GetComponent<ITask>().SabotageTask();
                GetComponent<ICharacterInterface>().UpdateTaskList();
            }
            else
            {
                Debug.LogWarning("Cool Down remains: " + (coolDown - curTime + prevSabotageTime));
            }
        }
        else
        {
            Debug.Log("Tasks are not found");
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Time.time - prevSabotageTime);
        }
        else
        {
            float otherDeltaTime= (float) stream.ReceiveNext();
            if (Time.time - prevSabotageTime > otherDeltaTime)
            {
                prevSabotageTime = Time.time - otherDeltaTime;
            }
        }
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    
}
