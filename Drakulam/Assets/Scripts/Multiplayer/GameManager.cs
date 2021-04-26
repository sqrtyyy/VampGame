using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameManager : MonoBehaviourPunCallbacks
{
    public Transform _vampireSpawn;
    public Transform _humanSpawn;
    public GameObject _humanPrefab;
    public GameObject _vampPrefub;

    public Transform _humanUI;
    public Transform _vampUI;

    public AudioSource beginningMusic;
    static private GameObject player;
    int _nVampires = 1;
    string namePlayerPrefub;
    Transform _UI;

    private double _timeStart;

    private double _timePeriod = 10 * 60;
    private bool _started = false;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        _timeStart = 0;
        if (PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            Spawn(_humanPrefab, _humanUI, _humanSpawn);
            TaskManager.Instance().TasksSetPlayerInfo(new PlayerInfo(PlayerInfo.CharacterClass.Human));
        }
        else
        {
            Spawn(_vampPrefub, _vampUI, _vampireSpawn);
            TaskManager.Instance().TasksSetPlayerInfo(new PlayerInfo(PlayerInfo.CharacterClass.Vampire));
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            photonView.RPC("StartGame", RpcTarget.All);
    }

    private void Spawn(GameObject playerPrefub, Transform ui, Transform spawnPoint)
    {
        namePlayerPrefub = playerPrefub.name;
        _UI = Instantiate<Transform>(ui);
        _UI.SetParent(Camera.main.transform);
        player = PhotonNetwork.Instantiate(playerPrefub.name, spawnPoint.position, Quaternion.identity);
        player.GetComponent<CharacterControl>().isMuvable = false;
        player.GetComponent<ICharacterInterface>().SetUI(_UI.name);
        TaskManager.Instance().TasksSetPlayerInfo(new PlayerInfo(PlayerInfo.CharacterClass.Vampire));
    }

    // Update is called once per frame
    void Update()
    {
        if (_started && (PhotonNetwork.CurrentRoom.PlayerCount < 2 || _nVampires == 0))
            SceneManager.LoadScene(3); // human win
        //________________________________________
        /*
         * This is the condition that the player is dead and must be respawned, 
         * attempts to make a more beautiful and understandable condition led to strange behavior of the code
         * It would be nice to sort this out by the second demo. 
         */
        if (player == null) //
        {
            
            if (namePlayerPrefub == _humanPrefab.name)
            {
                IncNumVamp();
                photonView.RPC("IncNumVamp", RpcTarget.Others);
            }
            Destroy(_UI.gameObject);
            Spawn(_vampPrefub, _vampUI, _vampireSpawn);
            player.GetComponent<CharacterControl>().isMuvable = true;
            TaskManager.Instance().TasksSetPlayerInfo(new PlayerInfo(PlayerInfo.CharacterClass.Vampire));
        }
        //________________________________________
        //
        UpdateTimer();
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
        if (_timeStart == 0)
            return;
        if (!TaskManager.Instance().IsAllTasksCompleted())
            return;
        SceneManager.LoadScene(3);
    }

    void CheckVampWin()
    {
        if (_timeStart == 0)
            return;
        if (_timePeriod - (PhotonNetwork.Time - _timeStart) < 0 ||
            _nVampires == PhotonNetwork.CurrentRoom.MaxPlayers)
            SceneManager.LoadScene(4);
    }

    private void UpdateTimer()
    {
        int delteTime = (int)(_timePeriod - (PhotonNetwork.Time - _timeStart));
        if (_timeStart == 0 && delteTime < 0)
        {
            _UI.GetComponent<TimerUpdate>().UpdateTimer((int)_timePeriod / 60, (int)_timePeriod % 60);
            return;
        }
        int minutes = delteTime / 60;
        int seconds = delteTime % 60;
        _UI.GetComponent<TimerUpdate>().UpdateTimer(minutes, seconds);
    }

    [PunRPC]
    void IncNumVamp()
    {
        _nVampires++;
    }

    [PunRPC]
    private void StartGame() {
        _started = true;
        _timeStart = PhotonNetwork.Time;
        player.GetComponent<CharacterControl>().isMuvable = true;
        beginningMusic.Play();
    }

    public static void UpdateTaskList()
    {
        ICharacterInterface uiController;
        if (player != null &&
            (uiController = player.GetComponent<ICharacterInterface>()) != null)
            uiController.UpdateTaskList();
        else
            Debug.LogError("it is impossible to update the task list");
    }
}
