using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var position = new Vector3(Random.Range(-5f, 5f) - 15f, 0, 0);
        PhotonNetwork.Instantiate(PlayerPrefab.name, position, Quaternion.identity);
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
