using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWallControl : IControllable
{
    private BrokenWallInput _brickWallManager;
    public TaskDestroyedWall manager;

    private void Awake()
    {
        _brickWallManager = new BrokenWallInput();
        _brickWallManager.BrokenWall.next.performed += ctx => { manager.NextTrigger(); };
   
    }

    private void OnEnable()
    {
        _brickWallManager.Enable();
    }

    private void OnDisable()
    {
        _brickWallManager.Disable();
    }
}