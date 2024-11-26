using UnityEngine;

public class FlipBurger : MonoBehaviour
{
    [SerializeField] private Animator _animator; 

    [SerializeField] private TargetHandler _targetHandler;
    private GameObject m_currentTarget;
    private Rigidbody m_currentTargetRigidbody;

    [SerializeField] private float _flipForce;
    [SerializeField] private float _flipTorque;

    private bool m_isFlippable;

    public void MoveSpatulaToBurger(bool flag)
    {
        if (m_isFlippable)
        {
            Flip();

            return;
        }

        _animator.SetBool("MoveSpatulaToBurger", flag);
    }

    public void Attach()
    {
        m_currentTarget = _targetHandler.CurrentTarget;

        if (m_currentTarget == null) return;

        m_currentTargetRigidbody = _targetHandler.CurrentTarget.GetComponent<Rigidbody>();

        m_currentTargetRigidbody.isKinematic = true;

        m_currentTarget.transform.SetParent(transform, true);

        m_currentTarget.transform.position = transform.position;

        m_isFlippable = true;
    }

    public void Flip()
    {
        m_isFlippable = false;

        m_currentTarget.transform.parent = null;

        m_currentTargetRigidbody.isKinematic = false;

        m_currentTargetRigidbody.AddForce((Vector3.forward + Vector3.up ).normalized * _flipForce, ForceMode.Impulse);

        m_currentTargetRigidbody.AddTorque(Vector3.right * _flipTorque, ForceMode.Impulse);

        _animator.SetBool("MoveSpatulaToBurger", false);

        _animator.SetBool("FlipBurger", true);
    }

    public void Detach()
    {
        _animator.SetBool("FlipBurger", false);
    }
}
