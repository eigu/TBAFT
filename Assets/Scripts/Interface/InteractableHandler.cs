using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractableHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _onStartInteract;
    [SerializeField] private UnityEvent _onStopInteract;

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.performed) _onStartInteract?.Invoke();

        else if (context.canceled) _onStopInteract?.Invoke();
    }
}
