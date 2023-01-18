using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTypeCheck : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _cabinFloorLayer;
    public bool _isPlayerInside { get; private set; }
    private Transform _transform;
    private void Awake()
    {
        _transform = gameObject.transform;
    }
    private void Update()
    {
        _isPlayerInside = Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _cabinFloorLayer);
    }
}
