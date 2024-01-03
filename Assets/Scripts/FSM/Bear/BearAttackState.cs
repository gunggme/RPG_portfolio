using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttackState : BearStateBase
{
    public override void Enter(BearBossController target)
    {
        target.Agent.enabled = false;
        base.Enter(target);
    }

    public override void Execute(BearBossController target)
    {
        if (target.distance > target.attackDistance)
        {
            target.ChangeState(BearState.Move);
            return;
        }
        
        if (target.tempAttackTimer > target.attackTimer)
        {
            target.tempAttackTimer = 0;
            // 공격 애니메이션 싱행
            int attackNum = Random.Range(1, 5);
            target.Animators.SetTrigger("Attack" + attackNum);
        }
        else
        {
            target.tempAttackTimer += Time.deltaTime;
        }
        base.Execute(target);
    }

    public override void Exit(BearBossController target)
    {
        target.Agent.enabled = true;
        base.Exit(target);
    }
}
