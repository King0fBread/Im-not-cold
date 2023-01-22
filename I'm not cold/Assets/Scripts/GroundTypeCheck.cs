using UnityEngine;

public class GroundTypeCheck : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _cabinFloorLayer;
    private bool _isPlayerInside;
    private Transform _transform;
    private void Awake()
    {
        _transform = gameObject.transform;
    }
    private void Update()
    {
        _isPlayerInside = Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _cabinFloorLayer);
        SurvivalStatesManager.instance.isPlayerInside = _isPlayerInside;
    }
}
