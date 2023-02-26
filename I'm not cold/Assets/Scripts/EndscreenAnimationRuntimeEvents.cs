using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndscreenAnimationRuntimeEvents : MonoBehaviour
{
    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void DisableAllSounds()
    {
        SoundsManager.instance.SilenceAllSounds();
    }
}
