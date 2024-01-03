using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSleepState : BearStateBase
{
    public override void Enter(BearBossController target)
    {
        target.Agent.enabled = false;
    }

    public override void Execute(BearBossController target)
    {
        if (target.distance < target.AwakeDistance)
        {
            target.ChangeState(BearState.Idle);
        }
    }

    public override void Exit(BearBossController target)
    {
        
    }
}
