using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotUseText : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("ObjFalse", 1);
    }

    void ObjFalse()
    {
        gameObject.SetActive(false);
    }
}
