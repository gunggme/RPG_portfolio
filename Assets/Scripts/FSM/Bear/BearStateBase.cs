using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum BearState
{
    Sleep,
    Idle,
    Move,
    Attack,
    Stun,
    Hit,
    Death
}

public abstract class BearStateBase : IFSM<BearBossController>
{
    public virtual void Enter(BearBossController target)
    {
        
    }

    public virtual void Execute(BearBossController target)
    {
        
    }

    public virtual void Exit(BearBossController target)
    {
        
    }
}
