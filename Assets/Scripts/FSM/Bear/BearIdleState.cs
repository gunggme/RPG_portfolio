using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearIdleState : BearStateBase
{
    public override void Enter(BearBossController target)
    {
        target.Agent.enabled = false;
        target.Animators.SetTrigger("Awake");
        target.damageable.OnHPBar(target.IconImage);
        base.Enter(target);
    }

    public override void Execute(BearBossController target)
    {
        if (target.distance > target.attackDistance)
        {
            target.ChangeState(BearState.Move);
        }
        base.Execute(target);
    }

    public override void Exit(BearBossController target)
    {
        base.Exit(target);
    }
}
