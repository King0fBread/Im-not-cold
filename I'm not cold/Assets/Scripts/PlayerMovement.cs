using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
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
    //make sensitivity public eventually
    private float _rotationSensitivityX = 100f;
    private float _rotationSensitivityY = 100f;
    [Header("Jumping")]
    [SerializeField] private float _jumpStrength;
    public bool isGrounded { get; set; }
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jumping.performed += Jump;

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Move();
        RotateCamera();
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            _playerRigidbody.AddForce(Vector3.up * _jumpStrength, ForceMode.Impulse);
        }
    }
    private void Move()
    {
        _isRunning = Input.GetKey(KeyCode.LeftShift);
        _inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        _moveDirection = _orientationObjectTransform.forward * _inputVector.y + _orientationObjectTransform.right * _inputVector.x;
        SendMovementInfoToEnergyCounter();

        if (_isRunning)
        {
            _playerRigidbody.AddForce(_moveDirection.normalized * _runningSpeed * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            _playerRigidbody.AddForce(_moveDirection.normalized * _walkingSpeed * Time.deltaTime, ForceMode.Force);
        }
    }
    private void RotateCamera()
    {
        _mouseRotationAlongX = Input.GetAxis("Mouse X");
        _mouseRotationAlongY = Input.GetAxis("Mouse Y");
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
    private void OnDisable()
    {
        playerInputActions.Player.Jumping.performed -= Jump;
    }
}
