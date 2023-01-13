using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickAndDropItems : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _objectCarryingTransform;
    [SerializeField] private LayerMask _pickableItemLayer;
    [SerializeField] private float _pickupDistance;
    private GrabableObject _grabableObject;
    private void Awake()
    {
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Pickup.performed += PickupOrDropItem;
    }
    private void PickupOrDropItem(InputAction.CallbackContext context)
    {
        if (_grabableObject == null)
        {
            TryPickupObject();
        }
        else
        {
            DropObject();
        }
    }
    private void TryPickupObject()
    {
        if(Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit raycastHit, _pickupDistance, _pickableItemLayer))
        {
            raycastHit.transform.TryGetComponent(out _grabableObject);
            _grabableObject.Pick(_objectCarryingTransform);
        }
    }
    private void DropObject()
    {
        _grabableObject.Drop();
        _grabableObject = null;
    }
}
