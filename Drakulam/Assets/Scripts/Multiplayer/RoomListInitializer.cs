using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomListInitializer : MonoBehaviour
{
    public RectTransform prefub;
    public RectTransform content;
    public LobbyManager lobbyManager;

    public void UpdateItems()
    {
        GetItems(result => OnReceivedModels(result));
    }

    void OnReceivedModels(TestItemsModel[] models)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach(var model in models)
        {
            var instace = GameObject.Instantiate(prefub.gameObject) as GameObject;
            instace.transform.SetParent(content, false);
            InitializeItemView(instace, model);
        }
    }

    void InitializeItemView (GameObject viewGameObject, TestItemsModel model)
    {
        TestItemsView view = new TestItemsView(viewGameObject.transform);
        view.titleText.text = model.title;
        view.clickButton.GetComponentInChildren<Text>().text = model.buttonText;
        view.clickButton.onClick.AddListener(
            ()=>
            {
                Debug.Log(view.titleText.text + " is clicked");
                 if (model.isOpen)
                    lobbyManager.JoinRoom(view.titleText.text, "");
            }
        );
    }

    void GetItems (System.Action<TestItemsModel[]> callBack)
    {
        
        var result = new TestItemsModel[lobbyManager.roomList.Count];
        int i = 0;
        foreach (var item in lobbyManager.roomList)
        {
            result[i] = new TestItemsModel();
            result[i].title = item.Name;
            if (item.MaxPlayers > item.PlayerCount)
            {
                result[i].buttonText = "Войти";
                result[i].isOpen = true;
            }
            else
            {
                result[i].buttonText = "Закрато";
                result[i].isOpen = false;
            }
            i++;
        }

        callBack(result);
    }

    public class TestItemsView
    {
        public Text titleText;
        public Button clickButton;

        public TestItemsView (Transform rootView)
        {
            titleText = rootView.Find("RoomNameScroleText").GetComponent<Text>();
            clickButton = rootView.Find("RoomEnterScroleButton").GetComponent<Button>();
        }
    }

    public class TestItemsModel
    {
        public string title;
        public string buttonText;
        public bool isOpen;
    }
}

