using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDisplay;
    [SerializeField] private string _tag;

    [SerializeField] private float _flatThreshold;

    private int m_score;

    private void Update()
    {
        _textDisplay.text = $"SCORE: {m_score}";
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(_tag)) return;

        if (!IsBurgerFlat(other.gameObject)) return;

        m_score++;

        Destroy(other.gameObject);
    }

    private bool IsBurgerFlat(GameObject burger)
    {
        Vector3 burgerUp = burger.transform.up;

        float dotUp = Vector3.Dot(burgerUp.normalized, Vector3.up);
        float dotDown = Vector3.Dot(burgerUp.normalized, -Vector3.up);

        return Mathf.Abs(dotUp) > _flatThreshold || Mathf.Abs(dotDown) > _flatThreshold;
    }
}
