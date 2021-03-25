using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class VampireInterface : ICharacterInterface
{
    void Start()
    {
        Dictionary<string, Tuple<int, int>> allTasks = TaskManager.Instance().getAllTasks();
        taskListText.text = "Помешать: \n";
        foreach (KeyValuePair<string, Tuple<int, int>> entry in allTasks)
        {
            int numOfCompleted = entry.Value.Item1;
            int maxNumOfTasks = entry.Value.Item2;

            taskListText.text += entry.Key + numOfCompleted + "/" + maxNumOfTasks + "\n ";
        }
    }

    public override void UpdateTaskList()
    {
        Dictionary<string, Tuple<int, int>> allTasks = TaskManager.Instance().getAllTasks();
        taskListText.text = "Помешать: \n";
        foreach (KeyValuePair<string, Tuple<int, int>> entry in allTasks)
        {
            int numOfCompleted = entry.Value.Item1;
            int maxNumOfTasks = entry.Value.Item2;

            taskListText.text += entry.Key + numOfCompleted + "/" + maxNumOfTasks + "\n ";
        }
    }

    public override void SetMaxHealth(int healthPoints)
    {
        healthBar.maxValue = healthPoints;
    }

    public override void UpdateHealthBar(int healthPoints)
    {

    }
}
