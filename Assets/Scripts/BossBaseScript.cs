using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseScript : MonoBehaviour
{
    protected Damageable damageable;

    protected virtual void Awake()
    {
        damageable = GetComponent<Damageable>();
    }
    
    public virtual void Damaged(float dmg)
    {
        
    }
}
