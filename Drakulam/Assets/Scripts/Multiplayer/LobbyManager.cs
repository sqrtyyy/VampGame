using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private byte countPlayers = 4;
    public List<RoomInfo> roomList;
    public RoomListInitializer roomListInitializer;
    //public RoomListInitializer roomListInitializer;
    // Start is called before the first frame update
    void Start()
    {
        roomList = new List<RoomInfo>();
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1.0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        if (PhotonNetwork.JoinLobby())
            Debug.Log("Join the lobby");
        else
            Debug.Log("!!! fatal join the lobby !!!"); 
        //base.OnConnectedToMaster();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join the room");
        PhotonNetwork.LoadLevel("Main");
        //base.OnJoinedRoom();
    }

    public void CreateRoom(string name, string password)
    {
        foreach (var room in roomList)
            if (name == room.Name)

        if (!PhotonNetwork.IsConnectedAndReady)
            return;
        PhotonNetwork.CreateRoom(name, new Photon.Realtime.RoomOptions { MaxPlayers = countPlayers, IsOpen = true, IsVisible = true });
    }

    public void JoinRoom(string name, string password)
    {
        PhotonNetwork.JoinRoom(name);
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        Debug.Log("Room list:");
        roomList = RoomList;
        roomListInitializer.UpdateItems();
        foreach (var room in roomList)
            Debug.Log(room.Name);
    }
}
