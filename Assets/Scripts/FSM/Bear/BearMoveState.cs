using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMoveState : BearStateBase
{
    public override void Enter(BearBossController target)
    {
        target.Agent.enabled = true;
        target.Animators.SetBool("Move", true);
        base.Enter(target);
    }

    public override void Execute(BearBossController target)
    {
        if (target.distance < 2)
        {
            target.ChangeState(BearState.Attack);
        }
        else
        {
            target.Agent.destination = target._target.position;
        }
        base.Execute(target);
    }

    public override void Exit(BearBossController target)
    {
        target.Animators.SetBool("Move", false);
        target.Agent.enabled = false;
        base.Exit(target);
    }
}
