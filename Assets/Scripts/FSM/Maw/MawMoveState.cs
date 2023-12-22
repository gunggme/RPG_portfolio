using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawMoveState : BaseMawState
{
    public override void Enter(MawController target)
    {
        Debug.Log($"Cur State : {MawStates.Move}");
        target.Anim.SetBool("Move", true);
        target.Agent.enabled = true;
    }

    public override void Execute(MawController target)
    {
        if (target.curDirection < target._attackRange)
        {
            target.ChangeState(MawStates.Attack);
            return;
        }
        
        target.Agent.SetDestination(target._target.position);

        
    }

    public override void Exit(MawController target)
    {
        
    }
}
