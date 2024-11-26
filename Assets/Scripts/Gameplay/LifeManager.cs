using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private int _defaultPlayerLife;
    private int _currentPlayerLife;

    [SerializeField] private int _playerLifeDeduction;

    [SerializeField] private TextMeshProUGUI _textDisplay;
    [SerializeField] private string _tag;

    [SerializeField] private UnityEvent _onGameOver;

    private void Start()
    {
        _currentPlayerLife = _defaultPlayerLife;
    }

    private void Update()
    {
        if (_currentPlayerLife <= 0)
        {
            _onGameOver.Invoke();

            return;
        }

        _textDisplay.text = $"SALARY: ${_currentPlayerLife}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_tag)) return;

        DeductLife();

        Destroy(other.gameObject);
    }

    private void DeductLife()
    {

        _currentPlayerLife -= _playerLifeDeduction;
    }
}
