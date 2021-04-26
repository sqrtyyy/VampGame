using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    private const string CreditsSceneName = "Credits";
    private const string MenuSceneName = "menu";

    private CreditsActions controller;

    public void Awake()
    {
        controller = new CreditsActions();
        controller.CreditsMap.ExitCredits.performed += ctx => {
            LoadMenu();
        };
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuSceneName);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(CreditsSceneName);
    }
    
}
