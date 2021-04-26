using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    private const string CreditsSceneName = "Credits";
    private const string MenuSceneName = "menu";
    private bool IsOnCreditsScene = false;

    private CreditsActions controller;

    private void Start()
    {
        controller = new CreditsActions();
        controller.CreditsMap.Enable();
        controller.CreditsMap.ExitCredits.performed += ctx => {
            LoadMenu();
        };
    }

    public void LoadMenu()
    {
        if (IsOnCreditsScene)
        {
            SceneManager.LoadScene(MenuSceneName);
            IsOnCreditsScene = false;
        }
    }

    public void LoadCredits()
    {
        if (!IsOnCreditsScene)
        {
            SceneManager.LoadScene(CreditsSceneName);
            IsOnCreditsScene = true;
        }
    }
}
