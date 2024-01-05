using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDamageable : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    public float hp;
    public float maxHP;

    private void OnEnable()
    {
        hp = maxHP;
    }

    public void OnHPBar()
    {
        hpBar.gameObject.SetActive(true);
    }

    public bool IsDamage(float dmg)
    {
        hp -= dmg;
        
        if (hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
