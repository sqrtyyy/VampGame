using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class IHealth : MonoBehaviour
{
     protected int health;
    [SerializeField] protected int maxHealth = 0;
    public abstract void setHealth(int newHealth);
    public abstract void changeHealth(int delta);

    public int getHealth()
    {
        return health;
    }
}
