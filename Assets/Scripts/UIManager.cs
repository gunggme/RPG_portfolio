using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _statUI;
    public GameObject _inventory;
    public GameObject _shopUI;

    private void Update()
    {
        Cursor.lockState = (_shopUI.activeSelf || _statUI.activeSelf || _inventory.activeSelf)  ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = (_shopUI.activeSelf || _statUI.activeSelf || _inventory.activeSelf);
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            _statUI.SetActive(!_statUI.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _inventory.SetActive(!_inventory.activeSelf);
        }
    }
}
