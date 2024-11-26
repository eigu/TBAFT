using UnityEngine;
using UnityEngine.Events;

public class TargettableHandler : MonoBehaviour
{
    [SerializeField] private TargetHandler _targetHandler;

    [SerializeField] private UnityEvent<ITargettable> OnTargetChanged;

    private ITargettable m_currentTargettable;
    public ITargettable CurrentTargettable
    {
        get => m_currentTargettable;
        set
        {
            if (m_currentTargettable == value)
            {
                OnTargetChanged?.Invoke(value);

                return;
            }

            m_currentTargettable?.StopTarget();

            m_currentTargettable = value;

            m_currentTargettable?.StartTarget();

            OnTargetChanged?.Invoke(m_currentTargettable);
        }
    }

    private void Update()
    {
        AssignCurrentTargettable(_targetHandler.CurrentTarget);
    }

    public void AssignCurrentTargettable(GameObject currentTarget)
    {
        if (currentTarget == null)
        {
            ClearCurrentTargettable();

            return;
        }

        ITargettable target = currentTarget.GetComponent<ITargettable>();

        CurrentTargettable = target;
    }

    private void ClearCurrentTargettable()
    {
        if (CurrentTargettable == null) return;

        CurrentTargettable.StopTarget();

        CurrentTargettable = null;

        OnTargetChanged?.Invoke(null);
    }
}