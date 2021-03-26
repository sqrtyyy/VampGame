using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHealth : IHealth
{
    private Animator anim;

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
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("death")){};
            Destroy(gameObject);
        }
    }
    
    private IEnumerator Die()
    {
        // Play the animation for getting suck in
        anim.SetTrigger("death");

        yield return new WaitForSeconds(10);

        // Move this object somewhere off the screen
        

    }
}
