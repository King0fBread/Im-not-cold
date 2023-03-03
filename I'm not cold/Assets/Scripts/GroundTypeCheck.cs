using UnityEngine;

public class GroundTypeCheck : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _cabinFloorLayer;
    [SerializeField] private LayerMask _cabinOutsideFloorLayer;
    private Transform _transform;
    private PlayerParticles _playerParticles;

    //references for other scripts according to the player being inside/outside
    public bool playerNotEmittingBreathingParticles { get; private set; }
    public bool playerWalkingOnWood { get; private set; }
    public bool windShouldPlayFully { get; private set; }
    private void Awake()
    {
        _transform = gameObject.transform;
        _playerParticles = GetComponent<PlayerParticles>();
    }
    private void Update()
    {
        _playerParticles.isPlayerInside = playerNotEmittingBreathingParticles;
        SurvivalStatesManager.instance.isPlayerInside = playerNotEmittingBreathingParticles;

        if (Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _cabinFloorLayer))
        {
            playerNotEmittingBreathingParticles = true;
            playerWalkingOnWood = true;
            windShouldPlayFully = false;
        }
        else if(Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _cabinOutsideFloorLayer))
        {
            playerNotEmittingBreathingParticles = false;
            playerWalkingOnWood = true;
            windShouldPlayFully = true;
        }
        else
        {
            playerWalkingOnWood = false;
            windShouldPlayFully = true;
        }   
    }
}
