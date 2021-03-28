using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    private void Awake()
    {
        transform.position = spawnPoint.position;
    }

    public Transform spawnPoint;

}