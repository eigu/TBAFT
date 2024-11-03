using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSpatula : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private float _moveForce;

    private Vector3 _inputVector;

    public void Move(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();

        _rigidBody.velocity = new Vector3(
            _inputVector.x,
            0f,
            _inputVector.y);
    }
}
