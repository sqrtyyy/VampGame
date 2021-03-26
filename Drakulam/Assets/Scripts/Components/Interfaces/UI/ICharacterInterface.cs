using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class ICharacterInterface : MonoBehaviour
{
    public abstract void UpdateTaskList();

    public abstract void SetMaxHealth(int healthPoints);

    public abstract void UpdateHealthBar(int healthPoints);

    public abstract void UpdateTimer(int minutes, int seconds);

    public UnityEngine.UI.Slider healthBar;

    public GameObject taskList;

    public Text timerText;
}
