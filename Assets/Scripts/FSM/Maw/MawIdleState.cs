using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawIdleState : BaseMawState
{
    public override void Enter(MawController target)
    {
        Debug.Log($"Cur State : {MawStates.Idle}");
        target.Agent.enabled = false;
    }

    public override void Execute(MawController target)
    {
        if (target._detectedDir > target.curDirection)
        {
            // Move상태로 변경
            target.ChangeState(MawStates.Move);
        }
    }

    public override void Exit(MawController target)
    {
        
    }
}
