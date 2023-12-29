using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    private TMP_Text tmpText;

    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    public void SetHPBar(float curHP, float maxHP)
    {
        tmpText.text = $"{curHP}/{maxHP}";
    }
}
