using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorLogic : MonoBehaviour
{
    [SerializeField] private GameObject _mouseInteractionIcon;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _interactableDistance;
    [SerializeField] private FurnaceLogic _furnaceLogic;
    private Animator _doorAnimator;
    private bool _doorIsClosed = true;
    private bool _canInteractWithDoor = true;
    private bool _doorCurrentlyInMovement;
    private void Awake()
    {
        _doorAnimator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (!_canInteractWithDoor)
            return;

        _doorCurrentlyInMovement = true;
        if (_doorIsClosed)
        {
            _doorAnimator.Play("DoorOpening");
            _doorIsClosed = false;
            _furnaceLogic.isFrontDoorOpen = true;
        }
        else if (!_doorIsClosed)
        {
            _doorAnimator.Play("DoorClosing");
            _doorIsClosed = true;
            _furnaceLogic.isFrontDoorOpen = false;
        }
    }
    private void OnMouseOver()
    {
        if (CheckInteractableDistance() && !_doorCurrentlyInMovement)
        {
            _mouseInteractionIcon.SetActive(true);
            _canInteractWithDoor = true;
        }
        else if (!CheckInteractableDistance() || _doorCurrentlyInMovement)
        {
            _mouseInteractionIcon.SetActive(false);
            _canInteractWithDoor = false;
        }
    }
    private void OnMouseExit()
    {
        _mouseInteractionIcon.SetActive(false);
    }
    private bool CheckInteractableDistance()
    {
        return Vector3.Distance(transform.position, _playerTransform.gameObject.transform.position) <= _interactableDistance;
    }
    public void EnableDoorInteractions()
    {
        _doorCurrentlyInMovement = false;
    }
}
