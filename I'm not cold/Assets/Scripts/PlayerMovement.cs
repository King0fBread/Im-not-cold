using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;
    private Rigidbody _playerRigidbody;
    private Vector2 _inputVector;
    private Vector3 _moveDirection;
    private bool _isRunning;
    [Header("Rotation")]
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _orientationObjectTransform;
    private float _rotationX;
    private float _rotationY;
    private float _mouseRotationAlongX;
    private float _mouseRotationAlongY;
    public float rotationSensitivity { get; set; }
    [Header("Jumping")]
    [SerializeField] private float _jumpStrength;
    
    
    private PlayerInputActions playerInputActions;
    private GroundTypeCheck _groundTypeCheck;
    public bool isGrounded { get; set; }
    public bool canMove { get; set; }
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jumping.performed += Jump;

        _groundTypeCheck = GetComponent<GroundTypeCheck>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (canMove)
        {
            Move();
            RotateCamera();
        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (!canMove)
            return;

        if (isGrounded)
        {
            _playerRigidbody.AddForce(Vector3.up * _jumpStrength, ForceMode.Impulse);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerJumpingInitial);
        }
    }
    private void Move()
    {
        _isRunning = Input.GetKey(KeyCode.LeftShift);
        _inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        _moveDirection = _orientationObjectTransform.forward * _inputVector.y + _orientationObjectTransform.right * _inputVector.x;
        SendMovementInfoToEnergyCounter();
        if(_inputVector == Vector2.zero)
        {
            StopAllWalkingSounds();
            StopAllRunningSounds();
        }

        if (_isRunning)
        {
            SetSpeedToRunning();
            PlayCorrectRunningSound();
        }
        else
        {
            SetSpeedToWalking();
            PlayCorrectWalkingSound();
        }
    }
    private void SetSpeedToWalking()
    {
        _playerRigidbody.AddForce(_moveDirection.normalized * _walkingSpeed * Time.deltaTime, ForceMode.Force);
    }
    private void SetSpeedToRunning()
    {
        _playerRigidbody.AddForce(_moveDirection.normalized * _runningSpeed * Time.deltaTime, ForceMode.Force);
    }
    private void RotateCamera()
    {
        _mouseRotationAlongX = Input.GetAxis("Mouse X") * rotationSensitivity;
        _mouseRotationAlongY = Input.GetAxis("Mouse Y") * rotationSensitivity;
        _rotationX -= _mouseRotationAlongY;
        _rotationY += _mouseRotationAlongX;
        _rotationX = Mathf.Clamp(_rotationX, -80f, 80f);
        _orientationObjectTransform.rotation = Quaternion.Euler(0f, _rotationY, 0f);
        _cameraTransform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);
    }
    private void SendMovementInfoToEnergyCounter()
    {
        //Idling
        if(_inputVector == Vector2.zero)
        {
            SurvivalStatesManager.instance.isPlayerIdle = true;
        }
        //Moving
        else
        {
            SurvivalStatesManager.instance.isPlayerIdle = false;
            if (!_isRunning)
            {
                SurvivalStatesManager.instance.isPlayerRunning = false;
            }
            else
            {
                SurvivalStatesManager.instance.isPlayerRunning = true;
            }
        }
        //Jump occured
        if (isGrounded == false)
        {
            SurvivalStatesManager.instance.playerHasJumped = true;
        }
    }
    private void PlayCorrectWalkingSound()
    {
        StopAllRunningSounds();
        if (_groundTypeCheck.playerWalkingOnWood)
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerWalkingSnow);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerWalkingWood);
        }
        else
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerWalkingWood);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerWalkingSnow);
        }
    }
    private void PlayCorrectRunningSound()
    {
        StopAllWalkingSounds();
        if (_groundTypeCheck.playerWalkingOnWood)
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerRunningSnow);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerRunningWood);
        }
        else
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerRunningWood);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerRunningSnow);
        }
    }
    private void StopAllWalkingSounds()
    {
        SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerWalkingWood);
        SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerWalkingSnow);
    }
    private void StopAllRunningSounds()
    {
        SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerRunningWood);
        SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerRunningSnow);
    }
    private void OnDisable()
    {
        playerInputActions.Player.Jumping.performed -= Jump;
    }
}
