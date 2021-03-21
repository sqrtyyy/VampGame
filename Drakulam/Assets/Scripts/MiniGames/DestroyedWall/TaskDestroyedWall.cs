using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TaskDestroyedWall : ITask
{
    private static Random _randomize = new Random();
    private const int _randomBrickStart = 1;
    private const int _randomBrickEnd = 11;
    private const int _choosableBricksNumber = 3;
    private const string _brickImageName = "Brick_";
    [SerializeField]
    private bool _isCompleted = false;

    public override void StartTask()
    {
        
        _isCompleted = true;
    }

    public override void SabotageTask() { }
    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    private void _InitializeGame()
    {
        var destroyedBrick = _randomize.Next(_randomBrickStart, _randomBrickEnd);
        var anotherCoosableBricks = new int[_choosableBricksNumber - 1];
        for (var i = 0; i < _choosableBricksNumber - 1; ++i)
        {
            anotherCoosableBricks[i] = _randomize.Next(_randomBrickStart, _randomBrickEnd - 1);
            if (anotherCoosableBricks[i] >= destroyedBrick && anotherCoosableBricks[i] < _randomBrickEnd)
                anotherCoosableBricks[i]++;
        }

    }
}
