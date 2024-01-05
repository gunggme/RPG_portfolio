using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
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

        _bearScript = new Dictionary<BearState, BearStateBase>
        {
            { BearState.Sleep, new BearSleepState() },
            { BearState.Idle, new BearIdleState() },
            { BearState.Move, new BearMoveState() },
            { BearState.Attack, new BearAttackState() },
            { BearState.Death , new BearDieState()}
        };

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

    public override void Damaged(float dmg)
    {
        if (damageable.IsDamage(dmg))
        {
            ChangeState(BearState.Death);
        }
        base.Damaged(dmg);
    }
}
