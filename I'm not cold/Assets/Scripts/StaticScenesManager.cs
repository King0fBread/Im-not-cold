using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StaticScenesManager
{
    public enum Scenes
    {
        GameScene,
        MenuScene,
        LoadingScene
    }
    private static Action OnLoaderCallback;
    public static void LoadRequestedScene(Scenes sceneToLoad)
    {
        OnLoaderCallback = () =>
        {
            SceneManager.LoadSceneAsync(sceneToLoad.ToString());
        };
        SceneManager.LoadScene(Scenes.LoadingScene.ToString());
    }
    public static void LoaderCallback()
    {
        if(OnLoaderCallback != null)
        {
            OnLoaderCallback();
            OnLoaderCallback = null;
        }
    }
}
