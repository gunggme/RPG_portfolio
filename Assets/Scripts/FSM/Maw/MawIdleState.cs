using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawIdleState : BaseMawState
{
    public override void Enter(MawController target)
    {
        Debug.Log($"Cur State : {MawStates.Idle}");
    }

    public override void Execute(MawController target)
    {
        
    }

    public override void Exit(MawController target)
    {
        
    }
}
