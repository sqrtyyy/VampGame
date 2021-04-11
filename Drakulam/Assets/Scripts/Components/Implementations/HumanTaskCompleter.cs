﻿using UnityEngine;

public class HumanTaskCompleter : ITaskCompleter
{
    public Transform center;

    public LayerMask taskMask;

    public float radius;
    
    public override void FindTask()
    {
        Collider2D task = Physics2D.OverlapCircle(center.position, radius, taskMask);
        if (task)
        {
            task.GetComponent<ITask>().StartTask();
            GetComponent<ICharacterInterface>().UpdateTaskList();
        }
        else
        {
            Debug.Log("Tasks are not found");
        }
    }
}
