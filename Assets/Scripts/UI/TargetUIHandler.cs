using UnityEngine;

public class TargetUIHandler : MonoBehaviour
{
    public void HandleTargetChanged(ITargettable target)
    {
        if (target == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
