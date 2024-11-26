using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent _onStartInteract;

    [SerializeField] private UnityEvent _onStopInteract;

    public void StartInteract() => _onStartInteract?.Invoke();

    public void StopInteract() => _onStopInteract?.Invoke();
}
