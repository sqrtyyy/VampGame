using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireTaskDisabler : ITaskCompleter
{
    public Transform center;

    public LayerMask taskMask;

    public float radius;

    public override void FindTask()
    {
        Collider2D task = Physics2D.OverlapCircle(center.position, radius, taskMask);
        if (task)
        {
            task.GetComponent<ITask>().SabotageTask();
            GetComponent<ICharacterInterface>().UpdateTaskList();
        }
        else
        {
            Debug.Log("Tasks are not found");
        }
    }
}
