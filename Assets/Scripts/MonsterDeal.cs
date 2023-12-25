using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeal : MonoBehaviour
{
    private bool canDealDamage;

    public GameObject player;
    public LayerMask layer;

    [SerializeField] private float weaponLength;
    [SerializeField] private int weaponDamage;

    private void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layer))
            {
                // 적이 부딛혔을때
                if (hit.transform.TryGetComponent(out PlayerMovement PM) && player == null)
                {
                    PM.Damaged(weaponDamage);
                    player = PM.gameObject;
                }
            }
        }
    }
    
    public void StartDealDamage()
    {
        canDealDamage = true;
        player = null;
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
