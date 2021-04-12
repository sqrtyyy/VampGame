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

    public Transform _humanUI;
    public Transform _vampUI;

    private GameObject player;

    private string uiName;
    
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
        _humanUI.name = "UI";
        Transform UI = Instantiate<Transform>(_humanUI);
        UI.SetParent(Camera.main.transform);
        player = PhotonNetwork.Instantiate(_humanPrefab.name, _humanSpawn.position, Quaternion.identity);
        player.GetComponent<ICharacterInterface>().SetUI(UI.name);
        uiName = UI.name;
    }

    private void SpawnVampire()
    {
        Transform UI = Instantiate<Transform>(_vampUI);
        UI.SetParent(Camera.main.transform);
        player = PhotonNetwork.Instantiate(_vampPrefub.name, _vampireSpawn.position, Quaternion.identity);
        player.GetComponent<ICharacterInterface>().SetUI(UI.name);
        uiName = UI.name;
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
        }
        //________________________________________
        //

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
