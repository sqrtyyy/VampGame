using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public abstract class ICharacterInterface : MonoBehaviour
{
    public abstract void UpdateTaskList();

    public abstract void SetMaxHealth(int healthPoints);

    public abstract void UpdateHealthBar(int healthPoints);

    public void ShowTasks()
    {

    }

    public Text taskListText;

    public Slider healthBar;
}
