using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnDelay = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _spawnDelay, _spawnDelay);
    }

    private Vector3 GetRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        return new Vector3(x, 0f, z).normalized;
    }

    private void Spawn()
    {
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

        GameObject enemy = Instantiate(_enemy, _spawnPoints[spawnPointIndex]);
        enemy.GetComponent<EnemyMovement>().SetDirection(GetRandomDirection());
    }
}
