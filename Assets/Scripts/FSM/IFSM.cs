using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFSM<T>
{
    public void Enter(T target);
    public void Execute(T target);
    public void Exit(T target);
}
