using UnityEngine;

public class GroundTypeCheck : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _cabinFloorLayer;
    private bool _isPlayerInside;
    private Transform _transform;
    private PlayerParticles _playerParticles;
    private void Awake()
    {
        _transform = gameObject.transform;
        _playerParticles = GetComponent<PlayerParticles>();
    }
    private void Update()
    {
        _isPlayerInside = Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _cabinFloorLayer);
        _playerParticles.isPlayerInside = _isPlayerInside;
        SurvivalStatesManager.instance.isPlayerInside = _isPlayerInside;
    }
}
