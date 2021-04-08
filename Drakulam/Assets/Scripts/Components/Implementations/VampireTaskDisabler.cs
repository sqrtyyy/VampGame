using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireTaskDisabler : ITaskCompleter
{
    public Transform center;

    public LayerMask taskMask;

    public float radius;

    private static float coolDown = 15;
    private static float prevSabotageTime = -15;

    public static float getPercents()
    {
        float curTime = Time.time;
        float deltaTime = curTime - prevSabotageTime;
        return coolDown < deltaTime ? 1 : deltaTime / coolDown;
    }

    public override void FindTask()
    {
        Collider2D task = Physics2D.OverlapCircle(center.position, radius, taskMask);
        if (task)
        {
            float curTime = Time.time;
            if (curTime - prevSabotageTime > coolDown)
            {
                Debug.Log("SABOTAGE!!!!!");
                prevSabotageTime = curTime;
                task.GetComponent<ITask>().SabotageTask();
                GetComponent<ICharacterInterface>().UpdateTaskList();
            }
            else
            {
                Debug.Log("Cool Down remains: " + (coolDown - curTime + prevSabotageTime));
            }
        }
        else
        {
            Debug.Log("Tasks are not found");
        }
    }
}
