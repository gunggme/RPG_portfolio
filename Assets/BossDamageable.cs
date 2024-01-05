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

    public void OnHPBar(Sprite sprite)
    {
        hpBar.gameObject.SetActive(true);
        hpBar.GetComponentInChildren<Image>().sprite = sprite;
    }

    public void OffHPBar()
    {
        hpBar.gameObject.SetActive(false);
    }

    public bool IsDamage(float dmg)
    {
        hp -= dmg;
        hpBar.value = hp / maxHP;
        
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
