using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearBossController : BossBaseScript
{ 
    BearState _curState;
    private Dictionary<BearState, BearStateBase> _bearScript;

    public Transform _target;

    [Header("Player Distance")] public float distance;

    [Header("Idle State")] public float attackDistance;

    // Components
    private NavMeshAgent _agent;
    public NavMeshAgent Agent;
    private Animator _animator;
    public Animator Animators
    {
        get
        {
            return _animator;
        }
    }
    
    protected override void Awake()
    {
        base.Awake();
        _target = FindObjectOfType<PlayerMovement>().transform;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _bearScript[_curState].Execute(this);
        if (_curState != BearState.Death)
        {
            distance = Vector3.Distance(transform.position, _target.transform.position);
        }
    }

    public void ChangeState(BearState _newState)
    {
        _bearScript[_curState].Exit(this);
        _curState = _newState;
        _bearScript[_curState].Enter(this);
    }
    
}
