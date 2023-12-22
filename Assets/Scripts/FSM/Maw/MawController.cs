using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MawController : MonoBehaviour
{
    public Transform _target;
    
    public MawStates curState;

    private Dictionary<MawStates, BaseMawState> stateScripts;
    
    [Header("IdleState")]
    public float _detectedDir;
    [Header("MoveState")] 
    public float _moveSpeed;
    [Header("AttackState")] 
    public float _attackDmg;
    public float _attackRange;
    public float _attackTimer = 0;

    public float curDirection;
    
    // Componenets
    private NavMeshAgent _agent;
    public NavMeshAgent Agent
    {
        get
        {
            return _agent;
        }
    }
    private Animator _animator;
    public Animator Anim
    {
        get
        {
            return _animator;
        }
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _target = FindObjectOfType<PlayerMovement>().transform;
        
        stateScripts = new Dictionary<MawStates, BaseMawState>();
        stateScripts.Add(MawStates.Idle, new MawIdleState());
        stateScripts.Add(MawStates.Move, new MawMoveState());
        stateScripts.Add(MawStates.Attack, new MawAttackState());
    }

    private void OnEnable()
    {
        ChangeState(MawStates.Idle);
    }

    private void Update()
    {
        stateScripts[curState].Execute(this);
        if (curState != MawStates.Die)
        {
            curDirection = Vector3.Distance(transform.position, _target.position);
            Debug.Log(curDirection);
        }
    }

    public void ChangeState(MawStates state)
    {
        stateScripts[curState].Exit(this);
        curState = state;
        stateScripts[curState].Enter(this);
    }
}
