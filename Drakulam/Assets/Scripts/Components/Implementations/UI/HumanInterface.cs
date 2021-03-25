using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class HumanInterface : ICharacterInterface
{
    void Start()
    {
        UpdateTaskList();

    }

    public override void UpdateTaskList()
    {
        Dictionary<string, Tuple<int, int>> allTasks = TaskManager.Instance().getAllTasks();
        taskListText.text = "Нужно: \n";
        foreach (KeyValuePair<string, Tuple<int, int>> entry in allTasks)
        {
            int numOfCompleted = entry.Value.Item1;
            int maxNumOfTasks = entry.Value.Item2;

            taskListText.text += entry.Key + " " + numOfCompleted + "/" + maxNumOfTasks + " \n";
        }
        taskListText.text += "roororororoorororoorotreterreterterterterter 0/7 \n";
        taskListText.text += "ewrwerwerwer 0/1 \n";
        taskListText.text += "ewrwerwerwer 7/1 \n";
        taskListText.text += "ewrwerwerwer 7/1 \n";
    }

    public override void SetMaxHealth(int healthPoints)
    {
        healthBar.maxValue = healthPoints;
    }

    public override void UpdateHealthBar(int healthPoints)
    {
        healthBar.value = healthPoints;
    }
}
