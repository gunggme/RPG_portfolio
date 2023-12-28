using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Text;
using UnityEngine;

public class ChatWindow : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private TMP_Text _text;
    public int _chatIndex;
    public bool isShop;
    private bool isFirst;
    public string[] chatString;
    public GameObject shopUI;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnEnable()
    {
        isFirst = false;
        _chatIndex = 0;
        playerMovement.isMove = false;
        
    }

    void Update()
    {
        if (!isFirst)
        {
            StartCoroutine(TypeTextEffect(chatString[_chatIndex]));
            _chatIndex++;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_chatIndex == chatString.Length)
            {
                if (isShop)
                {
                    shopUI.SetActive(true);
                }
                gameObject.SetActive(false);
                return;
            }
            StartCoroutine(TypeTextEffect(chatString[_chatIndex]));

            _chatIndex++;
        }
    }

    IEnumerator TypeTextEffect(string text)
    {
        if (!isFirst)
        {
            isFirst = true;
        }
        _text.text = string.Empty;

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var t in text)
        {
            stringBuilder.Append(t);
            _text.text = stringBuilder.ToString();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnDisable()
    {
        playerMovement.isMove = true;
    }
}
