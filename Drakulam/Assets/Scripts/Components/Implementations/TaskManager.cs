using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Utils;

public class TaskManager 
{

    public TaskManager()
    {
        InitDictionary();
    }


    public static TaskManager Instance()
    {

        if (_instance == null)
        {
            _instance = new TaskManager();
        }
        return _instance;
    }

    public void Update(string taskName, bool isTaskCompleted)
    {
        Tuple<int, int> taskInfo;
        if (allTasks.TryGetValue(taskName, out taskInfo))
        {
            int newNumOfCompleted;
            int maxNumOfTasks = taskInfo.Item2;

            if (isTaskCompleted)
            {
                newNumOfCompleted = taskInfo.Item1 + 1;
            }
            else
            {
                newNumOfCompleted = taskInfo.Item1 <= 0 ? 0 : taskInfo.Item1 - 1;
            }

            allTasks[taskName] = new Tuple<int, int>(newNumOfCompleted, maxNumOfTasks);


            //If already one type of tasks if done check for others, maybe it is a winning case for people
            if (newNumOfCompleted == maxNumOfTasks)
            {
                if(IsAllTasksCompleted())
                {
                    Debug.Log($"Hurray");
                }
            }

        }

        foreach (KeyValuePair<string, Tuple<int, int>> entry in allTasks)
        {
            Debug.Log($"task: {entry.Key}");
            Debug.Log($"active: {entry.Value.Item1} max {entry.Value.Item2}");
        }
    }

    public void TasksSetPlayerInfo(PlayerInfo playerInfo)
    {
        GameObject[] tasks = GameObject.FindGameObjectsWithTag("Task");
        foreach (var task in tasks)
        {
            var taskObject = task.GetComponent<ITask>();
            if (taskObject != null)
                taskObject.SetPlayerInfo(playerInfo);
        }
    }

    private void InitDictionary()
    {
        GameObject[] tasks = GameObject.FindGameObjectsWithTag("Task");
        foreach (var task in tasks)
        {
            Tuple<int, int> taskInfo;
            string taskName = task.GetComponent<ITask>().GetTaskName();

            if (allTasks.TryGetValue(taskName, out taskInfo))
            {
                allTasks[taskName] = new Tuple<int, int>(taskInfo.Item1, taskInfo.Item2 + 1);
            }
            else
            {
                allTasks[taskName] = new Tuple<int, int>(0, 1);
            }
        }

    }

    public bool IsAllTasksCompleted()
    {
        foreach (KeyValuePair<string, Tuple<int, int>> entry in allTasks)
        {
            int NumOfCompleted = entry.Value.Item1;
            int maxNumOfTasks = entry.Value.Item2;
            if (NumOfCompleted != maxNumOfTasks)
            {
                return false;
            }
        }

        return true;
    }

    public Dictionary<string, Tuple<int, int>> getAllTasks()
    {
        return allTasks;
    }

    private static TaskManager _instance = null;

    /**
     * Key - task name
     * Value - pair (numOfCompletedTasks, maxTasks)
     **/
    Dictionary<string, Tuple<int, int>> allTasks = new Dictionary<string, Tuple<int, int>>();

}