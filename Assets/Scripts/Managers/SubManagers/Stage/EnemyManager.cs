using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float _spawnTimer = 0f;
    [SerializeField] private float _spawnInterval;

    private void Awake()
    {
        _spawnTimer = _spawnInterval;
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
        if(StageManager.IsGameEnd())
        {
            StageManager.Unit.SpawnEnemyUnit();
        }
    }
}
