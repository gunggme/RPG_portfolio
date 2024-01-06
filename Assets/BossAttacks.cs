using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public float dmg;
    
    private GameObject playerObj;
    private Collider col;

    void Start()
    {
        col = GetComponent<Collider>();
    }
    
    
    public void AttackStart()
    {
        col.enabled = true;
        playerObj = null;
    }

    public void AttackEnd()
    {
        col.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!playerObj && other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.Damaged(dmg);
            playerObj = other.gameObject;
        }
    }
}
