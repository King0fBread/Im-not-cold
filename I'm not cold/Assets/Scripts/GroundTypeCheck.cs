using UnityEngine;

public class GroundTypeCheck : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _cabinFloorLayer;
    private Transform _transform;
    private PlayerParticles _playerParticles;
    public bool isPlayerInside { get; private set; }
    private void Awake()
    {
        _transform = gameObject.transform;
        _playerParticles = GetComponent<PlayerParticles>();
    }
    private void Update()
    {
        isPlayerInside = Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _cabinFloorLayer);
        _playerParticles.isPlayerInside = isPlayerInside;
        SurvivalStatesManager.instance.isPlayerInside = isPlayerInside;
    }
}
