using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTask : ITask
{
    private bool _isCompleted = false;
    
    public override void StartTask()
    {
        Debug.Log("The task started");
        _isCompleted = true;
    }

    public override void SabotageTask() { }
    public override bool IsCompleted()
    {
        return _isCompleted;
    }
    public override string GetTaskName()
    {
        return "Simple task.";
    }
}
