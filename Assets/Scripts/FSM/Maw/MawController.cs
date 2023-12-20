using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawController : MonoBehaviour
{
    public MawStates curState;

    private Dictionary<MawStates, BaseMawState> stateScripts;

    private void Awake()
    {
        stateScripts = new Dictionary<MawStates, BaseMawState>();
        stateScripts.Add(MawStates.Idle, new MawIdleState());
    }

    private void OnEnable()
    {
        ChangeState(MawStates.Idle, new MawIdleState());
    }

    private void Update()
    {
        stateScripts[curState].Execute(this);
    }

    void ChangeState(MawStates state, BaseMawState newState)
    {
        stateScripts[curState].Exit(this);
        curState = state;
        stateScripts[curState].Enter(this);
    }
}
