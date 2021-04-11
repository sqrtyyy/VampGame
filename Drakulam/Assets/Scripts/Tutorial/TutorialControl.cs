using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : IControllable
{
    private TutoriaInput _tutorialManager;
    public TutorialManager manager;

    private void Awake()
    {
        _tutorialManager = new TutoriaInput();
        _tutorialManager.Tutorial.atack.canceled += ctx => { manager.AttackTrigger(); };
        _tutorialManager.Tutorial.next.performed += ctx => { manager.NextTrigger(); };
        _tutorialManager.Tutorial.move.canceled += ctx => { manager.MoveTrigger(); };
   
    }

    private void OnEnable()
    {
        _tutorialManager.Enable();
    }

    private void OnDisable()
    {
        _tutorialManager.Disable();
    }
}
