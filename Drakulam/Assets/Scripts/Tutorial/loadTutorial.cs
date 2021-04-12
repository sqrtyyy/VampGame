using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadTutorial : MonoBehaviour
{
    public void StartTutorial()
    {
        SceneManager.LoadScene("GameTutorial");
    }
}
