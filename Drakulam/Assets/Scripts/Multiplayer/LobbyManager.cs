using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private byte countPlayers = 2;
    public Dictionary<string, RoomInfo> roomDict;
    public RoomListInitializer roomListInitializer;
    //public RoomListInitializer roomListInitializer;
    // Start is called before the first frame update
    void Start()
    {
        roomDict = new Dictionary<string, RoomInfo>();
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Connect()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1.0.0";
        PhotonNetwork.ConnectUsingSettings();
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
        if (!PhotonNetwork.IsConnectedAndReady)
            return;
        
        foreach (var room in roomDict.Values)
            if (name == room.Name)
            {
                JoinRoom(room.Name, "");
                return;
            }
        PhotonNetwork.CreateRoom(name, new Photon.Realtime.RoomOptions { MaxPlayers = countPlayers, IsOpen = true, IsVisible = true });
    }

    public void JoinRoom(string name, string password)
    {
        PhotonNetwork.JoinRoom(name);
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        Debug.Log("Room list:");
        //roomList = RoomList;
        foreach (var room in RoomList)
        {
            if (room.PlayerCount != 0 && room.PlayerCount != room.MaxPlayers)
                if (!roomDict.ContainsKey(room.Name))
                    roomDict.Add(room.Name, room);
                else
                    roomDict[room.Name] = room;
            else
                if (roomDict.ContainsKey(room.Name))
                    roomDict.Remove(room.Name);
        }
        roomListInitializer.UpdateItems();
        foreach (var room in roomDict.Values)
            Debug.Log(room.Name);
    }
}
