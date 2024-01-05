using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearDieState : BearStateBase
{
    public override void Enter(BearBossController target)
    {
        target.enabled = false;
        target.Animators.SetTrigger("Die");
        target.damageable.OffHPBar();
    }

    public override void Execute(BearBossController target)
    {
        
    }

    public override void Exit(BearBossController target)
    {
        
    }
}
