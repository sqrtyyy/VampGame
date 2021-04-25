using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdate : MonoBehaviour
{
    [SerializeField] Text timerText;

    public void UpdateTimer(int minutes, int seconds)
    {
        if (timerText == null)
            return;
        string gameTimerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = gameTimerString;
    }
}
