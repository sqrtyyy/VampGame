using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHealth : IHealth
{
    private Animator anim;
    private float deathAnimationLength = 3.5f;
    protected void Start()
    {
        anim = GetComponent<Animator>();
    }
    public override void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public override void changeHealth(int delta)
    {
        health += delta;
        Debug.Log(health);
        if (health <= 0)
        {
            anim.SetTrigger("death");
            Destroy(gameObject, deathAnimationLength);
        }
    }
}
