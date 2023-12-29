using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MawController : MonoBehaviour
{
    public Transform _target;
    
    public MawStates curState;

    private Dictionary<MawStates, BaseMawState> stateScripts;

    public MonsterDeal monsterDeal;
    
    [Header("IdleState")]
    public float _detectedDir;
    [Header("MoveState")] 
    public float _moveSpeed;
    [Header("AttackState")] 
    public float _attackDmg;
    public float _attackRange;
    public float _attackRange2;
    public float _attackTimer = 0;

    public float curDirection;

    public GameObject applePrefab;
    
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
    private Damageable damageable;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _target = FindObjectOfType<PlayerMovement>().transform;
        
        stateScripts = new Dictionary<MawStates, BaseMawState>();
        stateScripts.Add(MawStates.Idle, new MawIdleState());
        stateScripts.Add(MawStates.Move, new MawMoveState());
        stateScripts.Add(MawStates.Attack, new MawAttackState());
        stateScripts.Add(MawStates.Hit, new MawHitState());
        stateScripts.Add(MawStates.Die, new MawDieState());
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
            //Debug.Log(curDirection);
        }
    }

    public void ChangeState(MawStates state)
    {
        stateScripts[curState].Exit(this);
        curState = state;
        stateScripts[curState].Enter(this);
    }

    public void Damaged(float dmg)
    {
        if (curState == MawStates.Hit)
        {
            return;
        }
        
        if (!damageable.Damaged(dmg))
        {
            ChangeState(MawStates.Die);
        }
        else
        {
            ChangeState(MawStates.Hit);
        }
    }
    
    public void StartDealDamage()
    {
        monsterDeal.StartDealDamage();
    }

    public void EndDealDamage()
    {
        monsterDeal.EndDealDamage();
    }

    public void ChangeMove()
    {
        ChangeState(MawStates.Move);
    }

    public void SpawnItem()
    {
        Instantiate(applePrefab, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
    }
}
