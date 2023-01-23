using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private List<Collider> _collidersToIgnore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger == false)
        {
            _playerMovement._isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_collidersToIgnore.Contains(other))
            return;

        if (other.isTrigger)
        {
            _playerMovement._isGrounded = false;
        }
    }
}
