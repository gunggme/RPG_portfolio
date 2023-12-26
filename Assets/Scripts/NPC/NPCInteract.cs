using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : InteractionBase
{
    public string _chat;
    
    public GameObject _chatWindow;
    public TMP_Text _text;

    protected override void Interaction_Check()
    {
        _chatWindow.SetActive(true);
        StartCoroutine(TypeTextEffect(_chat));
        base.Interaction_Check();
    }
    
    IEnumerator TypeTextEffect(string text)
    {
        _text.text = string.Empty;

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            stringBuilder.Append(text[i]);
            _text.text = stringBuilder.ToString();
            yield return new WaitForSeconds(0.01f);
        }
    }
}
