using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TaskDestroyedWall : ITask
{
    private static Random _randomize = new Random();
    private const int _randomBrickStart = 1;
    private const int _randomBrickEnd = 11;
    //private const int _choosableBricksNumber = 3;
    private const string _brickImageName = "Brick_";

    private Point[] _brickCenters = new Point[]
    {
        new Point(-7, 20), new Point(13, 20), new Point(-15, 10),
        new Point(5, 10), new Point(-11, 1), new Point(10, 1), new Point(-6, -8),
        new Point(14, -8), new Point(-16, -18), new Point(-1, -18), new Point(14, -18)
    };
    private bool _isCompleted = false;
    public Sprite[] bricksSprites;
    public GameObject graphics;
    public GameObject crack;
    public GameObject[] bricks;

    public override void StartTask()
    {
        _InitializeGame();
        graphics.SetActive(true);
        while(true) {}
        _isCompleted = true;
    }

    public override void SabotageTask() { }
    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    private void _InitializeGame()
    {
        var choosableBricks = new int[_randomBrickEnd];
        
        // generate random sequense of possible bricks
        for (int i = 0; i < _randomBrickEnd; ++i)
        {
            int j = _randomize.Next(i + 1);
            if (j != i)
                choosableBricks[i] = choosableBricks[j];
            choosableBricks[j] = i + 1;
        }
        //pick only bricks.Length first bricks from random sequense from previous step
        for (int i = 0; i < bricks.Length; ++i)
            bricks[i].GetComponent<Image>().sprite = bricksSprites[choosableBricks[i]];
        int k = _randomize.Next(bricks.Length);
        var destroyedBrick = choosableBricks[k];
        crack.GetComponent<RectTransform>().position = new Vector3(
            _brickCenters[destroyedBrick].X, _brickCenters[destroyedBrick].Y, 0);
        ;
        
    }
    public override string GetTaskName()
    {
        return "Destroyed wall task.";
    }
}
