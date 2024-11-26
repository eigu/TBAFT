using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour, ITargettable
{
    [SerializeField] private UnityEvent _onStartTarget;

    [SerializeField] private UnityEvent _onStopTarget;

    public void StartTarget() => _onStartTarget?.Invoke();

    public void StopTarget() =>_onStopTarget?.Invoke();
}
