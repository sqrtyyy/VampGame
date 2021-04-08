using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : IControllable
{
    private TutoriaInput _tutorialManager;

    private void Awake()
    {
        _tutorialManager = new TutoriaInput();
        _tutorialManager.Tutorial.atack.performed += ctx => { GetComponent<TutorialManager>().AttackTrigger(); };
        _tutorialManager.Tutorial.next.performed += ctx => { GetComponent<TutorialManager>().NextTrigger(); };
        _tutorialManager.Tutorial.move.performed += ctx => { GetComponent<TutorialManager>().MoveTrigger(); };
    }
}
