using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsRequestedObserver : MonoBehaviour
{
    [SerializeField] private GameObject _settingsObject;
    private void Start()
    {
        _settingsObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _settingsObject.SetActive(!_settingsObject.activeSelf);
        }
    }
}
