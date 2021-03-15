using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
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
        //base.OnConnectedToMaster();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join the room");
        PhotonNetwork.LoadLevel("FirstLevel");
        //base.OnJoinedRoom();
    }

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnectedAndReady)
            return;
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 6 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
