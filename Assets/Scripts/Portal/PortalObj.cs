using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalObj : InteractionBase
{
    public string moveSceneName;

    protected override void Interaction_Check()
    {
        LoadScene.LoadScenes(moveSceneName);
        base.Interaction_Check();
    }
}
