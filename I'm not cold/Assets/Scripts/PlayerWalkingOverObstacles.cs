using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingOverObstacles : MonoBehaviour
{
    [SerializeField] private Transform _lowerRaycastTransform;
    [SerializeField] private Transform _upperRaycastTransform;
    [SerializeField] private float _stepAmount;
    private Rigidbody _thisRb;
    private void Awake()
    {
        _thisRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckForRaycastCollisions();
        Debug.DrawRay(_lowerRaycastTransform.position, _lowerRaycastTransform.TransformDirection(Vector3.forward), Color.green, 0.1f);
    }
    private void CheckForRaycastCollisions()
    {
        RaycastHit lowerHitFoward;
        if(Physics.Raycast(_lowerRaycastTransform.position, _lowerRaycastTransform.TransformDirection(Vector3.forward), out lowerHitFoward, 0.1f))
        {
            print("low hit");
            RaycastHit upperHitForward;
            if (!Physics.Raycast(_upperRaycastTransform.position, _upperRaycastTransform.TransformDirection(Vector3.forward), out upperHitForward, 0.2f))
            {
                print("NO up hit");
                _thisRb.position -= new Vector3(0f, -_stepAmount, 0f);
            }
        }
    }
}
