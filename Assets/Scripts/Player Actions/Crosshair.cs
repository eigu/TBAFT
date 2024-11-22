using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _raycastDistance;

    private ITargettable m_currentTarget;

    private void Update()
    {
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        Ray ray = _camera.ScreenPointToRay(screenCenter);

        if (!Physics.Raycast(ray, out RaycastHit hit, _raycastDistance)) return;

        ITargettable target = hit.collider.GetComponent<ITargettable>();

        if (target == null)
        {
            ClearCurrentTarget();

            return;
        }

        if (m_currentTarget == target) return;

        m_currentTarget?.OnTargetExit();

        m_currentTarget = target;

        m_currentTarget.OnTargetEnter();
    }

    private void ClearCurrentTarget()
    {
        if (m_currentTarget == null) return;

        m_currentTarget.OnTargetExit();

        m_currentTarget = null;
    }
}
