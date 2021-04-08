using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Photon.Pun;

public class HumanInterface : ICharacterInterface
{
    private PhotonView photonView;
    void Start()
    {
        photonView = PhotonView.Get(this);
        AsyncUpdateTaskList();
    }

    public override void UpdateTaskList()
    {
        AsyncUpdateTaskList();
        photonView.RPC("AsyncUpdateTaskList", RpcTarget.Others);
    }

    [PunRPC]
    private void AsyncUpdateTaskList()
    {
        Text taskListText = taskList.transform.Find("Viewport/Content/Text").GetComponent<Text>();

        Dictionary<string, Tuple<int, int>> allTasks = TaskManager.Instance().getAllTasks();
        taskListText.text = " Нужно: \n";
        foreach (KeyValuePair<string, Tuple<int, int>> entry in allTasks)
        {
            int numOfCompleted = entry.Value.Item1;
            int maxNumOfTasks = entry.Value.Item2;

            taskListText.text += " " + entry.Key + " " + numOfCompleted + "/" + maxNumOfTasks + "\n";
        }
    }

    public override void SetMaxHealth(int healthPoints)
    {
        healthBar.maxValue = healthPoints;
        healthBar.value = healthPoints;
    }

    public override void UpdateHealthBar(int healthPoints)
    {
        healthBar.value = healthPoints;
    }

    public override void UpdateTimer(int minutes, int seconds)
    {
        string gameTimerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = gameTimerString;
    }
}
