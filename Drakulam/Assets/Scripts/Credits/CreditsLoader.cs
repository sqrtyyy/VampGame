using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsLoader : MonoBehaviour
{
    // Start is called before the first frame update
    private const string CreditsSceneName = "Credits";

    public void LoadCredits()
    {
        SceneManager.LoadScene(CreditsSceneName);
    }
}
