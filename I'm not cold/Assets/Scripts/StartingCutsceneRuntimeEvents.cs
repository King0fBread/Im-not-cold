using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCutsceneRuntimeEvents : MonoBehaviour
{
    [SerializeField] private SurvivalStatesManager _survivalStatesManager;
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
        _survivalStatesManager.canChangeSurvivalStates = false;
    }
    public void EnableMovement()
    {
        _playerMovement.canMove = true;
        _animator.enabled = false;
        _survivalStatesManager.canChangeSurvivalStates = true;
    }
}
