using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    void Awake()
    {
        startTime = Time.time;
    }


    void Update()
    {
        float elapsedTime = Time.time - startTime;

        int minutes = (int)gameTime;
        int seconds = (int)((gameTime - elapsedTime) % 60);
        GetComponent<ICharacterInterface>().UpdateTimer(minutes, seconds);

        // It can be a loosing case for humans
        if (elapsedTime >= gameTime)
        {
            GetComponent<ICharacterInterface>().UpdateTimer(0, 0);
        }
    }

    public float gameTime;

    private float startTime;
}
