using UnityEngine;

public class TargetBurger : MonoBehaviour, ITargettable
{
    [SerializeField] private Outline _outline;

    public void OnTargetEnter()
    {
        _outline.enabled = true;
    }

    public void OnTargetExit()
    {
        _outline.enabled = false;
    }
}
