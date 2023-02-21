using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLoaderForButtons : MonoBehaviour
{
    public void LoadGameScene()
    {
        Time.timeScale = 1;
        StaticScenesManager.LoadRequestedScene(StaticScenesManager.Scenes.GameScene);
    }
    public void LoadMenuScene()
    {
        StaticScenesManager.LoadRequestedScene(StaticScenesManager.Scenes.MenuScene);
    }
}
