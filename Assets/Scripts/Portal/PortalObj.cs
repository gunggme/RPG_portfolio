using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalObj : InteractionBase
{
    public string moveSceneName;
    public bool isOpen;
    public int price;

    protected override void Interaction_Check()
    {
        if(isOpen){
            LoadScene.LoadScenes(moveSceneName);
            base.Interaction_Check();
        }
        else
        {
            
        }
    }

    void CheckMoney(int money)
    {
        if (price < money)
        {
            return;
        }

        isOpen = true;
    }
}
