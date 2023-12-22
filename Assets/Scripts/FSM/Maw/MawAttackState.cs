using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawAttackState : BaseMawState
{
    public override void Enter(MawController target)
    {
        Debug.Log($"Cur State {MawStates.Attack}");
        target.Agent.enabled = false;
        target.Anim.SetBool("Move", false);
    }

    public override void Execute(MawController target)
    {
        target._attackTimer += Time.deltaTime;
        
        if (target.curDirection > target._attackRange2)
        {
            target.ChangeState(MawStates.Move);
            return;
        }
        if (target._attackTimer > 2)
        {
            target.transform.LookAt(new Vector3(target._target.position.x, target.transform.position.y, target._target.transform.position.z));
            target.Anim.SetTrigger("Attack");
            target._attackTimer = 0;
        }
    }

    public override void Exit(MawController target)
    {
        
    }
}
