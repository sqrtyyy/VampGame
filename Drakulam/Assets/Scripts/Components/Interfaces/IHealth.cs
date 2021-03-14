using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class IHealth : MonoBehaviour
{
    [SerializeField] protected int health;
    public abstract void setHealth(int newHealth);
    public abstract void changeHealth(int delta);

    public int getHealth()
    {
        return health;
    }
}
