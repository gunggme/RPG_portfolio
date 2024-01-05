using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAtttacker : MonoBehaviour
{
    private bool canDealDamage;

    public List<GameObject> enemys;
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
                if (hit.transform.TryGetComponent(out MawController mawController) && !enemys.Contains(hit.transform.gameObject))
                {
                    mawController.Damaged(weaponDamage);
                    enemys.Add(mawController.gameObject);
                }

                if (hit.transform.TryGetComponent(out BossBaseScript bossBaseScript))
                {
                    bossBaseScript.Damaged(weaponDamage);
                    enemys.Add(bossBaseScript.gameObject);
                }
            }
        }
    }
    
    public void StartDealDamage()
    {
        canDealDamage = true;
        enemys.Clear();
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
