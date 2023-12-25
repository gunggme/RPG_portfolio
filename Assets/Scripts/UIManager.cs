using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _statUI;

    private void Update()
    {
        Cursor.lockState = _statUI.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = _statUI.activeSelf;
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            _statUI.SetActive(!_statUI.activeSelf);
        }
    }
}
