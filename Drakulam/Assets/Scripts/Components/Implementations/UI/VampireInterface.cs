using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Photon.Pun;
using UnityEngine;

public class VampireInterface : ICharacterInterface
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
        taskListText.text = ""; // " Помешать: \n";
        foreach (KeyValuePair<string, Tuple<int, int>> entry in allTasks)
        {
            int numOfCompleted = entry.Value.Item1;
            int maxNumOfTasks = entry.Value.Item2;

            taskListText.text += " " + entry.Key + " " + numOfCompleted + "/" + maxNumOfTasks + "\n";
        }
    }

    public override void SetMaxHealth(int healthPoints)
    {
        if (healthBar == null)
            return;
        healthBar.maxValue = healthPoints;
        healthBar.value = healthPoints;
    }

    public override void UpdateHealthBar(int healthPoints)
    {
        if (healthBar == null)
            return;
        healthBar.value = healthPoints;
    }

    public override void UpdateTimer(int minutes, int seconds)
    {
        if (timerText == null)
            return;
        string gameTimerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = gameTimerString;
    }

    public override void SetUI(string uiName)
    {
        /*if (!photonView.IsMine)
            return;*/
        healthBar = Camera.main.transform.Find(uiName).Find("HealthBar").GetComponent<Slider>();
        taskList = Camera.main.transform.Find(uiName).Find("TaskList");
        taskList.Find("Target").GetComponent<Text>().text = " Помешать:";
        timerText = Camera.main.transform.Find(uiName).Find("Timer").GetComponent<Text>();
        AsyncUpdateTaskList();
    }
}
