using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBossController : BossBaseScript
{ 
    BearState _curState;
    private Dictionary<BearState, BearStateBase> _bearScript;

    private Transform _target;

    [Header("Player Distance")] public float distance;

    // Components
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
