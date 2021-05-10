using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HumanHealth : IHealth
{
    private Animator anim;
    [SerializeField] private float deathAnimationLength = 3.5f;
    private float prevSpawn = 0;
    private PhotonView photonView;
    private ISoundable m_sound;

    [SerializeField] private GameObject bloodSpotPrefab;
    private Queue<GameObject> bloodSpots;
    protected void Start()
    {
        anim = GetComponent<Animator>();
        m_sound = GetComponent<ISoundable>();
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
        if (health <= 0)
        {
            isDead = true;
            GetComponent<IControllable>().enabled = false;
            anim.SetTrigger("death");
            m_sound.playSound(ISoundable.SoundName.DEATH_SOUND);
            Destroy(gameObject, deathAnimationLength);
        }
        else //else for playing just one sound
        {
            m_sound.playSound(ISoundable.SoundName.HIT_REACTION_SOUND);
        }
    }

    void FixedUpdate(){
        if (!photonView.IsMine) return;
        if (health / (float)maxHealth < 0.5 && Time.time - prevSpawn > 1)
        {
            if (bloodSpots.Count > 10)
            {
                GameObject firstSpot = bloodSpots.Dequeue();
                PhotonNetwork.Destroy(firstSpot);
            }
            if (PhotonNetwork.IsConnectedAndReady && PhotonNetwork.CurrentRoom != null)
            {
                bloodSpots.Enqueue(PhotonNetwork.Instantiate(bloodSpotPrefab.name, transform.position,
                    Quaternion.identity));
            }
            else
            {
                bloodSpots.Enqueue(Instantiate(bloodSpotPrefab, transform.position,
                    Quaternion.identity));
            }

            prevSpawn = Time.time;
        }
        
    }
}
