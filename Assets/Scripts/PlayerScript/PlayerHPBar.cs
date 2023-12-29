using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHPBar : MonoBehaviour
{
    private TMP_Text hpBar;

    private void Awake()
    {
        hpBar = GetComponent<TMP_Text>();
    }

    public void HpBarSet(float curHP, float maxHP)
    {
        hpBar.text = $"HP\n{curHP}/{maxHP}";
    }
}
