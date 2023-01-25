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
    private void OnCollisionExit(Collision collision)
    {
        if (_collidersToIgnore.Contains(collision.collider))
            return;

        _playerMovement._isGrounded = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (_collidersToIgnore.Contains(collision.collider))
            return;

        _playerMovement._isGrounded = true;
    }
}
