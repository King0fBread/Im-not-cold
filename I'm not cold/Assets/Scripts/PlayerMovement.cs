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
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jumping.performed += Jump;
    }
    private void Update()
    {
        Move();
    }
    private void Jump(InputAction.CallbackContext context)
    {

    }
    private void Move()
    {
        _inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        _playerRigidbody.AddForce(new Vector3(_inputVector.x, 0, _inputVector.y).normalized * _walkingSpeed * Time.deltaTime, ForceMode.Force);
    }
}
