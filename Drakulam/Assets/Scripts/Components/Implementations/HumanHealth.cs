﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HumanHealth : IHealth
{
    private Animator anim;
    private float deathAnimationLength = 3.5f;
    private float prevSpawn = 0;
    private PhotonView photonView;

    [SerializeField] private GameObject bloodSpotPrefab;
    private Queue<GameObject> bloodSpots;
    protected void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<ICharacterInterface>().SetMaxHealth(maxHealth);
        health = maxHealth;
        bloodSpots = new Queue<GameObject>();
        photonView = GetComponent<PhotonView>();
    }
    public override void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public override void changeHealth(int delta)
    {
        health += delta;
        GetComponent<ICharacterInterface>().UpdateHealthBar(health);
        Debug.Log(health);
        if (health <= 0)
        {
            anim.SetTrigger("death");
            StartCoroutine(Die());
        }
    }

    IEnumerator Die(){
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return new WaitForSeconds(0.3f);
        }
        Destroy(gameObject, deathAnimationLength);
    }

    void Update(){
        if (!photonView.IsMine) return;
        if (health / (float)maxHealth < 0.5 && Time.time - prevSpawn > 2)
        {
            if (bloodSpots.Count > 5)
            {
                GameObject firstSpot = bloodSpots.Dequeue();
                Destroy(firstSpot);
            }
            Debug.LogWarning(" spawned");

            bloodSpots.Enqueue(PhotonNetwork.Instantiate(bloodSpotPrefab.name, transform.position, Quaternion.identity));
            prevSpawn = Time.time;
        }
        
    }
}
