using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    RaycastHit hit;
    public GameObject checkObj;
    public LayerMask layer;
    public float length;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, length, layer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.TryGetComponent(out InteractionBase IB))
                {
                    IB.Interaction();
                }

                if (hit.transform.TryGetComponent(out PortalObj portal))
                {
                    portal.CheckMoney(playerMovement.money);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * length);   
    }
}
