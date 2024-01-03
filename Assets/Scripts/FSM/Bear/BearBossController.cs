using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearBossController : BossBaseScript
{ 
    [SerializeField]
    BearState _curState;
    private Dictionary<BearState, BearStateBase> _bearScript;

    public Transform target;

    [Header("Player Distance")] public float distance;

    [Header("Idle State")] public float attackDistance;

    [Header("Sleep State")] public float AwakeDistance;

    [Header("Attack State")] public float tempAttackTimer;
    public float attackTimer;

    // Components
    private NavMeshAgent _agent;
    public NavMeshAgent Agent
    {
        get
        {
            return _agent;
        }
    }
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
        target = FindObjectOfType<PlayerMovement>().transform;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _bearScript = new Dictionary<BearState, BearStateBase>();
        
        _bearScript.Add(BearState.Sleep, new BearSleepState());
        _bearScript.Add(BearState.Idle, new BearIdleState());
        _bearScript.Add(BearState.Move, new BearMoveState());
        _bearScript.Add(BearState.Attack, new BearAttackState());
        _curState = BearState.none;
        //_bearScript.Add(BearState.Death, new ());
    }

    private void Start()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        ChangeState(BearState.Sleep);
    }

    private void Update()
    {
        if (_curState != BearState.none)
        {
            _bearScript[_curState].Execute(this);
        }
        if (_curState != BearState.Death)
        {
            distance = Vector3.Distance(transform.position, target.transform.position);
        }
    }

    public void ChangeState(BearState _newState)
    {
        if (_curState != BearState.none)
        {
            _bearScript[_curState].Exit(this);
        }
        
        _curState = _newState;
        _bearScript[_curState].Enter(this);
    }
    
}
