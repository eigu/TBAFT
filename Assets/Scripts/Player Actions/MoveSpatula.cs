using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSpatula : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _inputVector;
    [SerializeField] private float _inputClamp;

    public void Move(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();

        _rigidbody.velocity = new Vector3(
            Mathf.Clamp(_inputVector.x, -_inputClamp, _inputClamp),
            0f,
            Mathf.Clamp(_inputVector.y, -_inputClamp, _inputClamp));
    }
}
