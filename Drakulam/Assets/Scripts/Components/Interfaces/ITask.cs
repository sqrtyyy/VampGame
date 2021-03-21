using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITask : MonoBehaviour
{
    public abstract void StartTask();
    public abstract bool IsCompleted();
    public abstract void SabotageTask();
}
