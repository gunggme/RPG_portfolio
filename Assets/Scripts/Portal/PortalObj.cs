using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalObj : InteractionBase
{
    protected override void Interaction_Check()
    {
        LoadScene.LoadScenes("Forest");
        base.Interaction_Check();
    }
}
