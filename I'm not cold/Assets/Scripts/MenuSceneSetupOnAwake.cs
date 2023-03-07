using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneSetupOnAwake : MonoBehaviour
{
    [SerializeField] private GameObject _settingsObject;
    [SerializeField] private GameObject _difficultyObject;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        _settingsObject.SetActive(false);
        _difficultyObject.SetActive(false);
    }
}
