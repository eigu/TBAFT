using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private TargetHandler _targettableHandler;

    private void Start()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        ShootRaycast();
    }

    public void ShootRaycast()
    {
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        Ray ray = _camera.ScreenPointToRay(screenCenter);

        if (!Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _layerMask))
        {
            _targettableHandler.CurrentTarget = null;

            return;
        }

        _targettableHandler.CurrentTarget = hit.collider.gameObject;
    }
}
