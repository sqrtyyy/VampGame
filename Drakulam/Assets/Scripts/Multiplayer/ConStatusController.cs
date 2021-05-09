using UnityEngine;
using UnityEngine.UI;
using System;

public class ConStatusController : MonoBehaviour
{
    [SerializeField] Button retryBtn;
    [SerializeField] GameObject connectionFrame;
    [SerializeField] GameObject menuFrame;

    public void ShowBtn(Action callBack)
    {
        retryBtn.gameObject.SetActive(true);

        retryBtn.onClick.AddListener(() =>
        {
            callBack();
            retryBtn.onClick.RemoveAllListeners();
            retryBtn.gameObject.SetActive(false);
        });
    }

    public void FinishConnectin()
    {
        connectionFrame.SetActive(false);
        menuFrame.SetActive(true);
    }

    public void StartConnectin()
    {
        connectionFrame.SetActive(true);
        menuFrame.SetActive(false);
    }
}
