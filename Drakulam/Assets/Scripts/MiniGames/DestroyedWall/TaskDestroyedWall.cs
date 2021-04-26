﻿using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Random = System.Random;
using Photon.Pun;

public class TaskDestroyedWall : ITask
{
    private static Random _randomize = new Random();
    private const int _randomBrickNum = 11;
    //private const int _choosableBricksNumber = 3;
    private int _answer = -1;
    private ExclamationMark _exclamationMark;

    private Point[] _brickCenters = new Point[]
    {
        new Point(129, 173), new Point(327, 173), new Point(56, 89),
        new Point(244, 89), new Point(97, 9), new Point(295, 9), new Point(141, -76),
        new Point(330, -76), new Point(51, -164), new Point(184, -164), new Point(337, -164)
    };
    private bool _isCompleted = false;
    public Sprite[] bricksSprites;
    public GameObject graphics;
    public GameObject crack;
    public GameObject[] bricks;

    PhotonView photonView;

    private void Start()
    {
        photonView = PhotonView.Get(this);
        AddTaskManager(TaskManager.Instance());
        var exclamationMarkName = "ExclamationMark";
        _exclamationMark = Functions.GetScriptOnChild<ExclamationMark>(this, exclamationMarkName);
        if (_exclamationMark == null)
        {
            Debug.Log("EXMARK exclamation mark script is null");
            return;
        }
            
        _exclamationMark.canBeSabotaged = true;
    }


    public override void StartTask()
    {
        if (_isCompleted == true)
            return;
        _InitializeGame();
        graphics.SetActive(true);
        NotifyTaskManager(GetTaskName(), _isCompleted);
    }

    [PunRPC]
    void AsyncChangeStatus(bool isCompleted)
    {
        _isCompleted = isCompleted;
        NotifyTaskManager(GetTaskName(), isCompleted);
        _exclamationMark.ChangeStatus();
        /*if (isCompleted)
            _answer = -1;*/
    }

    public override void SabotageTask()
    {
        AsyncChangeStatus(false);
        if (PhotonNetwork.IsConnectedAndReady)
            photonView.RPC("AsyncChangeStatus", RpcTarget.Others, false);
        GameManager.UpdateTaskList();
    }
    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    private void _InitializeGame()
    {
        var choosableBricks = new int[_randomBrickNum];
        
        // generate random sequense of possible bricks
        for (int i = 0; i < _randomBrickNum; ++i)
        {
            int j = _randomize.Next(i + 1);
            if (j != i)
                choosableBricks[i] = choosableBricks[j];
            choosableBricks[j] = i + 1;
        }
        //pick only bricks.Length first bricks from random sequense from previous step
        for (int i = 0; i < bricks.Length; ++i)
            bricks[i].GetComponent<Image>().sprite = bricksSprites[choosableBricks[i]];
        _answer = _randomize.Next(bricks.Length - 1);
        Debug.Log(_answer);
        var destroyedBrick = choosableBricks[_answer];
        
        crack.GetComponent<RectTransform>().localPosition = new Vector3( _brickCenters[destroyedBrick].X, _brickCenters[destroyedBrick].Y, 0);
    
    }
    public override string GetTaskName()
    {
        return "Почините разрушенную стену.";
    }

    public override void SetPlayerInfo(PlayerInfo playerInfo)
    {
        if (_exclamationMark != null)
            _exclamationMark.SetPlayerClass(playerInfo.characterClass);
    }

    public void CloseGame()
    {
        graphics.SetActive(false);
    }

    public void CheckAnswer(int brickIndex)
    {
        Debug.Log("Проверяем ответ "+ brickIndex.ToString());
        if (brickIndex == _answer)
        {
            AsyncChangeStatus(true);
            if (PhotonNetwork.IsConnectedAndReady)
                photonView.RPC("AsyncChangeStatus", RpcTarget.Others, true);
            GameManager.UpdateTaskList();
            _answer = -1;
            CloseGame();
        }

    }
}
