﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public Transform _vampireSpawn;
    public Transform _humanSpawn;
    public GameObject _humanPrefab;
    public GameObject _vampPrefub;

    public Transform _humanUI;
    public Transform _vampUI;

    private GameObject player;
    [SerializeField]
    int _nVampires = 1;
    string namePlayerPrefub;
    private string uiName;
    Transform _UI;

    // Start is called before the first frame update
    void Start()
    {        
        if (PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers)
            SpawnHuman();
        else
            SpawnVampire();

        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            photonView.RPC("StartGame", RpcTarget.All);
    }

    private void SpawnHuman()
    {
        namePlayerPrefub = _humanPrefab.name;
        _humanUI.name = "UI";
        _UI = Instantiate<Transform>(_humanUI);
        _UI.SetParent(Camera.main.transform);
        player = PhotonNetwork.Instantiate(_humanPrefab.name, _humanSpawn.position, Quaternion.identity);
        player.GetComponent<CharacterControl>().isMuvable = false;
        player.GetComponent<ICharacterInterface>().SetUI(_UI.name);
        uiName = _UI.name;
    }

    private void SpawnVampire()
    {
        namePlayerPrefub = _vampPrefub.name;
        _UI = Instantiate<Transform>(_vampUI);
        _UI.SetParent(Camera.main.transform);
        player = PhotonNetwork.Instantiate(_vampPrefub.name, _vampireSpawn.position, Quaternion.identity);
        player.GetComponent<CharacterControl>().isMuvable = false;
        player.GetComponent<ICharacterInterface>().SetUI(_UI.name);
        uiName = _UI.name;
    }

    // Update is called once per frame
    void Update()
    {
        //________________________________________
        /*
         * This is the condition that the player is dead and must be respawned, 
         * attempts to make a more beautiful and understandable condition led to strange behavior of the code
         * It would be nice to sort this out by the second demo. 
         */
        if (player == null) //
        {
            player = PhotonNetwork.Instantiate(_vampPrefub.name, _vampireSpawn.position, Quaternion.identity);
            player.GetComponent<ICharacterInterface>().SetUI(uiName);
            player.GetComponent<CharacterControl>().isMuvable = true;
            if (namePlayerPrefub == _humanPrefab.name)
            {
                IncNumVamp();
                photonView.RPC("IncNumVamp", RpcTarget.Others);
            }
            namePlayerPrefub = _vampPrefub.name;
            Destroy(_UI);
            _UI = Instantiate<Transform>(_vampUI);
            _UI.SetParent(Camera.main.transform);
            player.GetComponent<ICharacterInterface>().SetUI(_UI.name);
        }
        //________________________________________
        //
        CheckHumanWin();
        CheckVampWin();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
        //base.OnLeftRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player inter the room" + newPlayer.NickName);
        //base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left the room" + otherPlayer.NickName);
        //base.OnPlayerLeftRoom(otherPlayer);
    }

    void CheckHumanWin()
    {
        if (!TaskManager.Instance().IsAllTasksCompleted())
            return;
        SceneManager.LoadScene(3);
    }

    void CheckVampWin()
    {
        if (_nVampires != PhotonNetwork.CurrentRoom.MaxPlayers)
            return;
        SceneManager.LoadScene(4);
    }

    [PunRPC]
    void IncNumVamp()
    {
        _nVampires++;
    }

    [PunRPC]
    private void StartGame()
    {
        player.GetComponent<CharacterControl>().isMuvable = true;
    }
}
