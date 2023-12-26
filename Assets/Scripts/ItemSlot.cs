using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image image;

    private ItemBaseScript _item;

    public ItemBaseScript Item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = _item.itemSprite;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
            
        }
    }
}
