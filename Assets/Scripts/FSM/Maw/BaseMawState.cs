using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum MawStates
{
    Idle,
    Move,
    Attack,
    Hit,
    Die
}

public abstract class BaseMawState : IFSM<MawController>
{
    
    
    public virtual void Enter(MawController target)
    {
        
    }

    public virtual void Execute(MawController target)
    {
        
    }

    public virtual void Exit(MawController target)
    {
        
    }
}
