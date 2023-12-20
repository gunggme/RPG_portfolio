using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float _hp;
    public float _maxHp;

    void Start()
    {
        _hp = _maxHp;
    }

    public bool Damaged(float dmg)
    {
        _hp -= dmg;

        if (_hp < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
