using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _inputVector;
    [SerializeField] private float _inputClamp;

    [SerializeField] private Collider _bounds;

    private void Update()
    {
        Bounds bounds = _bounds.bounds;

        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, bounds.min.x, bounds.max.x);
        position.y = Mathf.Clamp(position.y, bounds.min.y, bounds.max.y);
        position.z = Mathf.Clamp(position.z, bounds.min.z, bounds.max.z);

        transform.position = position;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();

        _rigidbody.velocity = new Vector3(
            Mathf.Clamp(_inputVector.x, -_inputClamp, _inputClamp),
            0f,
            Mathf.Clamp(_inputVector.y, -_inputClamp, _inputClamp));
    }
}
