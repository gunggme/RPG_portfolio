using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBaseScript : ScriptableObject
{
    [SerializeField] private string _questTitle;
    public string QuestTitle
    {
        get
        {
            return _questTitle;
        }
    }

    [SerializeField] private string _questComment;
    public string QuestComment
    {
        get
        {
            return _questComment;
        }
    }

}
