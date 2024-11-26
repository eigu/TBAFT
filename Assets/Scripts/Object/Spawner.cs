using UnityEngine;

public class BurgerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _burgerPrefab;

    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _spawnCount;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBurgers), 1f, _spawnInterval);
    }

    private void SpawnBurgers()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            Vector3 randomPosition = transform.position + (Random.insideUnitSphere * _spawnRadius);

            randomPosition.y = Mathf.Max(randomPosition.y, 0.5f);

            Instantiate(_burgerPrefab, randomPosition, Quaternion.identity);
        }
    }
}
