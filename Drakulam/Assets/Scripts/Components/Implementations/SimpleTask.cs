using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTask : ITask
{

    public override void StartTask()
    {
        Debug.Log("The task started");
    }
}
