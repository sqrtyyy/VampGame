using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject human;
    public GameObject vampire;
    public ITask task;
    public GameObject invisibleWall;
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
        vampire.GetComponent<Transform>().position = new Vector3(-107.46f, -2.42f, -3.29f);

        invisibleWall.SetActive(true);
        human.GetComponent<CharacterControl>().gameObject.SetActive(true);
        vampire.GetComponent<CharacterControl>().gameObject.SetActive(false);

        popUps[0].SetActive(true);
        _humanHealth.setHealth(10);
        _vampireHealth.setHealth(500);
    }
    
    private void EndHumanTutorial()
    {
        _humanHealth.setHealth(10);
        _vampireHealth.setHealth(100);
    }
    
    private void InitializeVampireTutorial()
    {
        _UI.gameObject.SetActive(false);
        // Destroy(_UI);
        _UI = Instantiate<Transform>(_vampUI);
        _UI.SetParent(Camera.main.transform);
        vampire.GetComponent<ICharacterInterface>().SetUI(_UI.name);
        vampire.GetComponent<Transform>().position = new Vector3(-94.22f, 26.3f, 0);

        vampire.GetComponent<CharacterControl>().isMuvable = true;

        /*if (human != null)
        {
            human.GetComponent<CharacterControl>().gameObject.SetActive(false);
        }*/
        vampire.GetComponent<CharacterControl>().gameObject.SetActive(true);
        Debug.Log("InitializeVampireTutorial ended");
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
                EndHumanTutorial();
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
    }
    
    public void AttackTrigger()
    {
        Debug.Log("attackTrigger");
        if (popUpIndex == TutorialHAttack)
        {
            CompleteStep();
            invisibleWall.SetActive(false);
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
            popUpIndex == TutorialVTaskList)
            CompleteStep();
        else if (popUpIndex == TutorialVMap)
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
    
}
