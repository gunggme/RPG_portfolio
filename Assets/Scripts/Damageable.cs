using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private TMP_Text hpText;    
    
    public float _hp;
    public float _maxHp;

    void Start()
    {
        _hp = _maxHp;
    }

    public bool Damaged(float dmg)
    {
        
        _hp -= dmg;
        if (hpText != null)
        {
            hpText.text = $"{_hp}/{_maxHp}";
        }
        Debug.Log($"{gameObject.name}, cur Hp = {_hp}");

        if (_hp <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
