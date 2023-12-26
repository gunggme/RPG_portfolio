using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemBaseScript> items;

    [SerializeField] private Transform slotParent;
    [SerializeField] private ItemSlot[] slots;

#if  UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<ItemSlot>();
    }
#endif

    void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].Item = items[i];
        }

        for (; i < slots.Length; i++)
        {
            slots[i].Item = null;
        }
    }

    public void AddItem(ItemBaseScript _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 찼습니다.");
        }
    }
}
