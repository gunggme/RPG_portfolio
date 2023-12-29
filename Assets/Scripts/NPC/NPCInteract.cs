using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class NPCInteract : InteractionBase
{
    public string[] _chatNormal;
    public bool isShop;
    public GameObject _chatWindow;
    public TMP_Text _text;

    protected override void Interaction_Check()
    {
        if (!_chatWindow.activeSelf)
        {
            _chatWindow.SetActive(true);
            _chatWindow.GetComponent<ChatWindow>().chatString = _chatNormal;
            if (isShop)
            {
                // 상점 창 열기
                _chatWindow.GetComponent<ChatWindow>().isShop = isShop;
            }
            base.Interaction_Check();
        }
    }
}
    
    
