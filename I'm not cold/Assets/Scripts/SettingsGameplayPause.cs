using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGameplayPause : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    private void OnEnable()
    {
        _playerMovement.canMove = false;
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable()
    {
        _playerMovement.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
