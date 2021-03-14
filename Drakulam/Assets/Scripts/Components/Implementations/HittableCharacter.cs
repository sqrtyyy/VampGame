using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableCharacter : IHittable
{
    public override void Hit(int damage)
    {
        GetComponent<IHealth>().changeHealth(-damage);
        GetComponent<Animator>().SetTrigger("hurt");
    }
}
