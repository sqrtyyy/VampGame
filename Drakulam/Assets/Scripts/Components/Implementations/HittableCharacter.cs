using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableCharacter : IHittable
{
    public override void Hit(int damage)
    {
        GetComponent<Animator>().SetTrigger("hurt");
        GetComponent<IHealth>().changeHealth(-damage);
    }
}
