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
    private Collider _grabbedCollider;
    private Collider _playerCollider;
    private PlayerInputActions _playerInputActions;
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.InteractionE.performed += PickupOrDropItem;
        _playerCollider = GetComponent<CapsuleCollider>();
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
            _grabbedCollider = _grabableObject.GetComponent<Collider>();
            Physics.IgnoreCollision(_playerCollider, _grabbedCollider, true);

            InventoryObserver.currentInventoryItem = _grabableObject.gameObject;

            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerPickUpItem);
        }
    }
    private void DropObject()
    {
        _grabableObject.Drop();
        _grabableObject = null;
        Physics.IgnoreCollision(_playerCollider, _grabbedCollider, false);

        InventoryObserver.currentInventoryItem = null;
    }
    public void DisposeOfGrabbedObject()
    {
        Destroy(_grabableObject.gameObject);
        _grabableObject = null;
        InventoryObserver.currentInventoryItem = null;
    }
    private void OnDestroy()
    {
        _playerInputActions.Player.InteractionE.performed -= PickupOrDropItem;
    }
}
