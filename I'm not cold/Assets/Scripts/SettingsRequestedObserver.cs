using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsRequestedObserver : MonoBehaviour
{
    [SerializeField] private GameObject _settingsObject;
    [SerializeField] private PlayerMovement _playerMovement;
    private void Start()
    {
        _settingsObject.SetActive(false);
        //Done to avoid interfering with the starting cutscene
        _playerMovement.canMove = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _settingsObject.SetActive(!_settingsObject.activeSelf);
            //Done to avoid movement sounds playing while in settings menu
            _playerMovement.StopAllWalkingSounds();
            _playerMovement.StopAllRunningSounds();
        }
    }
}
