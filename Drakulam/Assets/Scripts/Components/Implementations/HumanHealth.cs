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
        GetComponent<ICharacterInterface>().SetMaxHealth(health);
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
            Destroy(gameObject, deathAnimationLength);
        }
    }
}
