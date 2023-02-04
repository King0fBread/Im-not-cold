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
    public bool canInteractWithDoor { get; set; }
    private void Awake()
    {
        _doorAnimator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (!canInteractWithDoor)
            return;

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
        if (CheckInteractableDistance())
        {
            _mouseInteractionIcon.SetActive(true);
            canInteractWithDoor = true;
        }
        else if (!CheckInteractableDistance())
        {
            _mouseInteractionIcon.SetActive(false);
            canInteractWithDoor = false;
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
}
