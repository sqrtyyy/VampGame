using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDamageDealer : IDamageDealer
{
    public float timeBetweenAttacks;

    public Transform attackPos;

    public LayerMask EnemyMask;

    public float attackRadius;

    public int damage;

    public Animator anim;

    private float prevTime;
    
    
    protected void Start()
    {
        // anim = GetComponent<Animator>();
    }

    public override void Attack ()
    {
        if (Time.time - prevTime > timeBetweenAttacks)
        {
            anim.SetTrigger("attack");
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, EnemyMask);
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<IHittable>().Hit(damage);
            }
            GetComponent<ISoundable>().playSound(ISoundable.SoundName.ATTACK_SOUND);

            prevTime = Time.time;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}
