using Photon.Pun;
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
    
    
    // Start is called before the first frame update
    void Start()
    {        
        if (PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers)
            SpawnHuman();
        else
            SpawnVampire();
    }

    private void SpawnHuman()
    {
        PhotonNetwork.Instantiate(_humanPrefab.name, _humanSpawn.position, Quaternion.identity);
    }

    private void SpawnVampire()
    {
        PhotonNetwork.Instantiate(_vampPrefub.name, _vampireSpawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
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


}
