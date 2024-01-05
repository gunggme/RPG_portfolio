using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalObj : InteractionBase
{
    public string moveSceneName;
    public bool isOpen;
    public int price;

    public GameObject notUseText;

    private TMP_Text priceText;

    private void Start()
    {
        priceText = GetComponentInChildren<TMP_Text>();
        priceText.text = $"price : {price:N0}";
    }

    protected override void Interaction_Check()
    {
        if(isOpen){
            LoadScene.LoadScenes(moveSceneName);
            base.Interaction_Check();
        }
    }

    private void Update()
    {
        if (isOpen && priceText.gameObject.activeSelf)
        {
            priceText.gameObject.SetActive(false);
        }
    }

    public void CheckMoney(int money)
    {
        if (price <= money)
        {
            isOpen = true;
        }
        else
        {
            if (!notUseText.activeSelf)
            {
                notUseText.SetActive(true);
            }
        }
    }
}
