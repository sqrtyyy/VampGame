using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITask : MonoBehaviour
{
    public abstract void StartTask();

    public abstract bool IsCompleted();

    public abstract void SabotageTask();

    public abstract string GetTaskName();

    //-------------------------------------//

    /*public void AddTaskManager(TaskManager manager)
    {
        taskManager = manager;
    }

    public void NotifyTaskManager(string taskName, bool isTaskCompleted)
    {
        taskManager.Update(taskName, isTaskCompleted);
    }

    private TaskManager taskManager; */ 
}
