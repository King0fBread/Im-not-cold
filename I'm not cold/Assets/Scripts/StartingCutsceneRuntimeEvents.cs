using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCutsceneRuntimeEvents : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Animator _animator;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }
    public void DisableMovement()
    {
        _playerMovement.canMove = false;
    }
    public void EnableMovement()
    {
        _playerMovement.canMove = true;
        _animator.enabled = false;
    }
}
