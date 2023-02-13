using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NonAsyncScenesManager : MonoBehaviour
{
    public void NonAsyncLoadGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void NonAsyncLoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
