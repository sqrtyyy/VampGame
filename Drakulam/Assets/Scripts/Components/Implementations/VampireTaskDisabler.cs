using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireTaskDisabler : ITaskCompleter
{
    public Transform center;

    public LayerMask taskMask;

    public float radius;

    private static float coolDown = 15;
    private static float prevTime = -15;

    public override void FindTask()
    {
        Collider2D task = Physics2D.OverlapCircle(center.position, radius, taskMask);
        if (task)
        {
            float curTime = Time.time;
            if (curTime - prevTime > coolDown)
            {
                task.GetComponent<ITask>().SabotageTask();
                GetComponent<ICharacterInterface>().UpdateTaskList();
                prevTime = curTime;
            }
            else
            {
                Debug.Log("Cool Down remains: " + (coolDown - curTime - prevTime));
            }
        }
        else
        {
            Debug.Log("Tasks are not found");
        }
    }
}
