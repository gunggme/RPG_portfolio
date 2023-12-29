using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawDieState : BaseMawState
{
    public override void Enter(MawController target)
    {
        Debug.Log($"Cur State : {MawStates.Die}");
        target.Agent.enabled = false;
        target.StartCoroutine(Coroutine_Die(target));
    }

    IEnumerator Coroutine_Die(MawController target)
    {
        target.Anim.SetTrigger("Die");
        yield return new WaitForSeconds(5f);
        float randomInt = Random.Range(0f, 100f);
        if (randomInt < 30f)
        {
            // 아이템 소환
            target.SpawnItem();
        }
        target.gameObject.SetActive(false);
    }
}
