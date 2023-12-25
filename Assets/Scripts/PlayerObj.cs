using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    public GameObject _swordParent;
    
    public void StartDealTime()
    {
        _swordParent.GetComponentInChildren<PlayerSwordAtttacker>().StartDealDamage();
    }

    public void EndDealTime()
    {
        _swordParent.GetComponentInChildren<PlayerSwordAtttacker>().EndDealDamage();
    }
}
