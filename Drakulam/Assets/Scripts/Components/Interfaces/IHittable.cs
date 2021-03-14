using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHittable : MonoBehaviour
{
    public abstract void Hit(int damage);
}
