using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [Header("Stat")]
    public TMP_Text _name_text;
    public TMP_Text _str_text;
    public TMP_Text _hp_text;
    public TMP_Text _speed_text;
    public TMP_Text _defend_text;
    [Header("Buttons")] 
    public Button _str_button;
    public Button _hp_button;
    public Button _dex_button;
    public Button _defend_button;

    private void Start()
    {
        _name_text.text = SaveManager.instance._player_name;
        _str_text.text = $"STR : {SaveManager.instance._stat_str}";
        _hp_text.text = $"HP : {SaveManager.instance._stat_hp}";
        _speed_text.text = $"DEX : {SaveManager.instance._stat_speed}";
        _defend_text.text = $"DEFEND : {SaveManager.instance._stat_defend}";
    }

    public void StatUp(int isStat)
    {
        if (SaveManager.instance._stat_sp == 0)
        {
            return;
        }
        
        switch (isStat)
        {
            case 1:
                SaveManager.instance._stat_str++;
                break;
            case 2:
                SaveManager.instance._stat_hp++;
                break;
            case 3:
                SaveManager.instance._stat_speed++;
                break;
            case 4:
                SaveManager.instance._stat_defend++;
                break;
        }

        
        SaveManager.instance._stat_sp--;
        _name_text.text = SaveManager.instance._player_name;
        _str_text.text = $"STR : {SaveManager.instance._stat_str}";
        _hp_text.text = $"HP : {SaveManager.instance._stat_hp}";
        _speed_text.text = $"DEX : {SaveManager.instance._stat_speed}";
        _defend_text.text = $"DEFEND : {SaveManager.instance._stat_defend}";
    }
}
