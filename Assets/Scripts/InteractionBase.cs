using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionBase : MonoBehaviour
{
    public string explanation;

    protected virtual void Interaction_Check()
    {
        Debug.Log(gameObject.name);
    }

    public void Interaction()
    {
        Interaction_Check();
    }
}
