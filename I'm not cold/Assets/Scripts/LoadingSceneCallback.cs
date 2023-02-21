using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneCallback : MonoBehaviour
{
    private bool _isFirstFrame = true;
    private void Update()
    {
        if (_isFirstFrame)
        {
            _isFirstFrame = false;
            StaticScenesManager.LoaderCallback();
        }
    }
}
