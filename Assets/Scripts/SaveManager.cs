using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

class stat
{
    public string name;
    public string save_date;
    public int level = 1;
    public int _str = 5;
    public int _hp = 5;
    public int _speed = 5;
    public int _defend = 5;
    public int _sp;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    [Header("스탯 적용 구간")] 
    public PlayerMovement _pm;
    public PlayerSwordAtttacker _psa;
    
    [Header("Stats")] 
    private stat _stat;
    public string _player_name;
    public int _stat_str= 5;
    public int _stat_hp = 5;
    public int _stat_speed = 5;
    public int _stat_defend = 5;
    public int _stat_sp;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _stat = new stat();
    }

    public void LoadData()
    {
        string path = Path.Combine(Application.dataPath, "Data/PlayerStatData.json");
        string jsonData = File.ReadAllText(path);
        _stat = JsonUtility.FromJson<stat>(jsonData);
    }

    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(_stat);
        string path = Path.Combine(Application.dataPath, "Data/PlayerStatData.json");
        File.WriteAllText(path, jsonData);
    }
}
