using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float _spawnTimer = 0f;
    [SerializeField] private float _spawnInterval;

    private void Awake()
    {
        _spawnTimer = 0f;
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if(_spawnTimer >= _spawnInterval)
        {
            SpawnEnemyUnit();
            _spawnTimer = 0;
        }
    }

    private void SpawnEnemyUnit()
    {
        StageManager.Unit.SpawnEnemyUnit();
    }
}
