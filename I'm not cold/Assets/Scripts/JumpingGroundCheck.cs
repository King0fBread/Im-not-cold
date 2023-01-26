using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGroundCheck : MonoBehaviour
{
    [SerializeField] private List<Collider> _collidersToIgnore;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (_collidersToIgnore.Contains(collision.collider))
    //        return;

    //    _playerMovement._isGrounded = false;
    //}
    //private void OnCollisionStay(Collision collision)
    //{
    //    print("touched " + collision);
    //    if (_collidersToIgnore.Contains(collision.collider))
    //        return;

    //    _playerMovement._isGrounded = true;
    //}
    private void OnTriggerStay(Collider other)
    {
        if (_collidersToIgnore.Contains(other))
            return;

        _playerMovement.isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (_collidersToIgnore.Contains(other))
            return;

        _playerMovement.isGrounded = false;
    }
}
