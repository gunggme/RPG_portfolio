using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingUI : MonoBehaviour
{
    public ItemBaseScript _item;

    public Image shopImage;

    public int leftItem;
    public int price;

    public TMP_Text itemName;
    public TMP_Text leftText;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnEnable()
    {
        shopImage.sprite = _item.itemSprite;
        itemName.text = _item.name;
        foreach (ItemBaseScript a in playerMovement.Inventory.items)
        {
            if (a.name == _item.name)
            {
                leftItem++;
            }
        }

        leftText.text = $"left : {leftItem}\nprice : {price}";
    }
}
