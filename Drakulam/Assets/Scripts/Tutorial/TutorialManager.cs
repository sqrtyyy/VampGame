using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject human;
    public GameObject vampire;
    public ITask task;
    public Transform _humanUI;
    public Transform _vampUI;
    private Transform _UI;
    private HumanHealth _humanHealth;
    private HumanHealth _vampireHealth;
    private Transform _humanPose;
    private Transform _vampirePose;
    private Rigidbody2D _vampireBody;
    private int popUpIndex;

    private const int TutorialHMove = 0;
    private const int TutorialHTaskList = 1;
    private const int TutorialHTask = 2;
    private const int TutorialHTimer = 3;
    private const int TutorialHHealth = 4;
    private const int TutorialHAttack = 5;

    private const int TutorialVHumanDeath = 6;
    private const int TutorialVTaskList = 7;
    private const int TutorialVSabotage = 8;
    private const int TutorialVSabotageTimer = 9;
    private const int TutorialVMap = 10;
    private const int TutorialEnding = 11;
    
    private double _timeStart;

    private double _timePeriod = 1 * 60;
    private bool _started = false;

    private Vector3 lastHumanPos;

    private void CompleteStep()
    {
        popUps[popUpIndex].SetActive(false);
        popUpIndex++;
        popUps[popUpIndex].SetActive(true);
    }

    private void InitializeHumanTutorial()
    {
        _UI = Instantiate<Transform>(_humanUI);
        _UI.SetParent(Camera.main.transform);
        human.GetComponent<ICharacterInterface>().SetUI(_UI.name);

        human.GetComponent<CharacterControl>().isMuvable = true;
        //vampire.GetComponent<CharacterControl>().isMuvable = true;

        human.GetComponent<Transform>().position = new Vector3(-94.22f, 26.3f, 0);
        vampire.GetComponent<Transform>().position = new Vector3(-1000.46f, -500.42f, 0f);

        human.GetComponent<CharacterControl>().gameObject.SetActive(true);
        vampire.GetComponent<CharacterControl>().gameObject.SetActive(false);

        popUps[0].SetActive(true);
        
        _vampireHealth.setHealth(500);
        task.SetPlayerInfo(new PlayerInfo(PlayerInfo.CharacterClass.Human));
    }
    
    private void EndHumanTutorial()
    {
        _humanHealth.setHealth(10);
        _vampireHealth.setHealth(100);
    }
    
    private void InitializeVampireTutorial()
    {
        ChangeLight();
        _UI.gameObject.SetActive(false);
        _UI = Instantiate<Transform>(_vampUI);
        _UI.SetParent(Camera.main.transform);
        vampire.GetComponent<ICharacterInterface>().SetUI(_UI.name);
        vampire.GetComponent<Transform>().position = lastHumanPos;//_humanPose.position;

        vampire.GetComponent<CharacterControl>().isMuvable = true;

        vampire.GetComponent<CharacterControl>().gameObject.SetActive(true);
        task.SetPlayerInfo(new PlayerInfo(PlayerInfo.CharacterClass.Vampire));
    }
    
    private void EndVampireTutorial()
    {
        SceneManager.LoadScene("menu");
    }

    public void Exit()
    {
        EndVampireTutorial();
    }

    private void HumanDeathStep()
    {
        _vampirePose.position = _humanPose.position - new Vector3(0, 1, 0);
        lastHumanPos = human.GetComponent<Transform>().position;
        vampire.GetComponent<IDamageDealer>().Attack();
    }

    void Start()
    {
        popUpIndex = 0;
        _humanHealth = human.GetComponent<HumanHealth>();
        Debug.Log(_humanHealth);
        _vampireHealth = vampire.GetComponent<HumanHealth>();
        InitializeHumanTutorial();
        _humanPose = human.GetComponent<Transform>();
        _vampirePose = vampire.GetComponent<Transform>();
    }
    

    void Update()
    {
        // human
        if (popUpIndex == TutorialHTask && task.IsCompleted())
            CompleteStep();
        else if (popUpIndex == TutorialVHumanDeath)
        {
            if (human == null || _humanHealth.getHealth() == 0)
            {
                //EndHumanTutorial();
                InitializeVampireTutorial();
                CompleteStep();
            }
            else
            {
                HumanDeathStep();
            }
        }

        // vampire
        else if (popUpIndex == TutorialVSabotage && !task.IsCompleted())
        {
            Debug.Log("blablabla");
            CompleteStep();
        }

        UpdateTimer();
    }
    
    public void AttackTrigger()
    {
        Debug.Log("attackTrigger");
        if (popUpIndex == TutorialHAttack)
        {
            CompleteStep();
            vampire.SetActive(true);
        }
    }

    public void NextTrigger()
    {
        Debug.Log("nextTrigger");
        if (popUpIndex == TutorialHTaskList || 
            popUpIndex == TutorialHTimer || 
            popUpIndex == TutorialHHealth ||
            popUpIndex == TutorialVSabotageTimer ||
            popUpIndex == TutorialVTaskList || 
            popUpIndex == TutorialVMap)
            CompleteStep();
        else if (popUpIndex == TutorialEnding)
        {
            popUps[popUpIndex].SetActive(false);
            EndVampireTutorial();
        }
    }

    public void MoveTrigger()
    {
        Debug.Log("moveTrigger");
        if (popUpIndex == TutorialHMove)
            CompleteStep();
    }
    
    void ChangeLight()
    {
        Camera.main.transform.Find("HumanLight").gameObject.SetActive(false);
        Camera.main.transform.Find("HumanLight_NoNM").gameObject.SetActive(false);
        Camera.main.transform.Find("VampireLight").gameObject.SetActive(true);
        Camera.main.transform.Find("VampireLight_NoNM").gameObject.SetActive(true);
    }
    
    private void UpdateTimer()
    {
        int delteTime = (int)(_timePeriod - (Time.time - _timeStart));
        if (_timeStart == 0 && delteTime < 0)
        {
            _UI.GetComponent<TimerUpdate>().UpdateTimer((int)_timePeriod / 60, (int)_timePeriod % 60);
            return;
        }
        int minutes = delteTime / 60;
        int seconds = delteTime % 60;
        _UI.GetComponent<TimerUpdate>().UpdateTimer(minutes, seconds);
    }
    
}
