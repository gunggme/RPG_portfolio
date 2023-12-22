using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawHitState : BaseMawState
{
    public override void Enter(MawController target)
    {
        target.Anim.SetTrigger("Hit");
    }
}
