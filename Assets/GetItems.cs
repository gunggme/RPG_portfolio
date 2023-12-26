using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItems : MonoBehaviour
{
    public ItemBaseScript _item;
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.Inventory.AddItem(_item);
            gameObject.SetActive(false);
        }
    }
}
