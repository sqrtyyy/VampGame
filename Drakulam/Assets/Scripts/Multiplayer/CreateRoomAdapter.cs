using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomAdapter : MonoBehaviour
{
    public Text roomName;
    public Text roomPassword;
    public LobbyManager lobbyManager;

    public void CreateRoom()
    {
        lobbyManager.CreateRoom(roomName.text, roomPassword.text);
    }
}
