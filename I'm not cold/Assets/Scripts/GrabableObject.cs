using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    private Rigidbody _thisRigidbody;
    private Transform _objectCarryingTransform;
    private float _lerpingToNewPositionSpeed = 20f;
    private void Awake()
    {
        _thisRigidbody = GetComponent<Rigidbody>();
    }
    public void Pick(Transform objectCarryingTransform)
    {
        _objectCarryingTransform = objectCarryingTransform;
        _thisRigidbody.useGravity = false;
        _thisRigidbody.freezeRotation = true;
        transform.rotation = Quaternion.identity;
    }
    public void Drop()
    {
        _objectCarryingTransform = null;
        _thisRigidbody.useGravity = true;
        _thisRigidbody.freezeRotation = false;
    }
    private void Update()
    {
        if (_objectCarryingTransform == null) 
            return;

        Vector3 newObjectPosition = Vector3.Lerp(transform.position, _objectCarryingTransform.position, Time.deltaTime * _lerpingToNewPositionSpeed);
        _thisRigidbody.MovePosition(newObjectPosition);
    }
}
