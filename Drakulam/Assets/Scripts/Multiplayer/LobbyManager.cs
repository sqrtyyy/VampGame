using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private byte countPlayers = 3;
    public Dictionary<string, RoomInfo> roomDict;
    public RoomListInitializer roomListInitializer;
    [SerializeField] SendMsgAdapter startMsg;
    [SerializeField] SendMsgAdapter bottomMsgBar;
    [SerializeField] ConStatusController conController;
    // Start is called before the first frame update
    void Start()
    {
        roomDict = new Dictionary<string, RoomInfo>();
        conController.StartConnectin();
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Connect()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            conController.FinishConnectin();
            return;
        }
        startMsg.ShowMsg(MSG.CONNECTION);
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1.0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        if (PhotonNetwork.JoinLobby())
        {
            Debug.Log("Join the lobby");
            startMsg.ShowMsg(MSG.JOIN_LOBBY);
        }
        else
        {
            startMsg.ShowMsg(MSG.JOIN_FAILED);
            conController.ShowBtn(() =>
            {
                Connect();
            });
            Debug.Log("!!! fatal join the lobby !!!");
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        bottomMsgBar.ShowMsg(MSG.CREATE_ROOM_FAILED, 5);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        bottomMsgBar.ShowMsg(MSG.JOIN_FAILED, 5);
    }

    public override void OnJoinedLobby()
    {
        conController.FinishConnectin();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join the room");
        PhotonNetwork.LoadLevel("Main");
    }

    public void CreateRoom(string name, string password)
    {
        if (!PhotonNetwork.IsConnectedAndReady)
            return;
        bottomMsgBar.ShowMsg(MSG.JOIN_ROOM);
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
        bottomMsgBar.ShowMsg(MSG.JOIN_ROOM);
        PhotonNetwork.JoinRoom(name);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        bottomMsgBar.ShowMsg(MSG.JOIN_FAILED, 3);
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        Debug.Log("Room list:");
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
