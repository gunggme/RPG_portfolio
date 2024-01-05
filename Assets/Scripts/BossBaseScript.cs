using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseScript : MonoBehaviour
{
    [SerializeField] public Sprite IconImage;
    
    public BossDamageable damageable;

    protected virtual void Awake()
    {
        damageable = GetComponent<BossDamageable>();
    }
    
    public virtual void Damaged(float dmg)
    {
        
    }
}
