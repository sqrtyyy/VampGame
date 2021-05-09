using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] String sceneNameToLoad;

    private LoadSceneAct _loadSceneAct;
    private void Start()
    {
        _loadSceneAct = new LoadSceneAct();
        _loadSceneAct.Enable();
        _loadSceneAct.LoadScene.Escape.performed += ctx =>
        {
            LoadScene();
        };
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}