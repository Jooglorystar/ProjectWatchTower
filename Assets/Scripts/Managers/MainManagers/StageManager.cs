using System.Collections.Generic;
using UnityEngine;

public class StageManager : SingletonObject<StageManager>
{
    private static UnitManager _unit;
    private static EnemyManager _enemy;
    public static UnitManager Unit => _unit;
    public static EnemyManager Enemy => _enemy;

    private static DefenceCore _playerCore;
    private static DefenceCore _enemyCore;

    [SerializeField] private SpawnPosition _playerSpawnPosition;
    [SerializeField] private SpawnPosition _enemySpawnPosition;

    private Dictionary<GameObject, IDamagable> _targetDict = new Dictionary<GameObject, IDamagable>();
    
    public SpawnPosition PlayerSpawnPosition => _playerSpawnPosition;
    public SpawnPosition EnemySpawnPosition => _enemySpawnPosition;

    public Dictionary<GameObject, IDamagable> TargetDict => _targetDict;

    protected override void Awake()
    {
        base.Awake();

        _unit = GetComponentInChildren<UnitManager>();
        _enemy = GetComponentInChildren<EnemyManager>();
    }

    private void OnEnable()
    {
        CreateCores();
    }

    private void CreateCores()
    {
        _playerCore = CreateCore(PlayerSpawnPosition);
        _playerCore.gameObject.layer = LayerMask.NameToLayer("Player");
        _enemyCore = CreateCore(EnemySpawnPosition);
        _enemyCore.gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    private DefenceCore CreateCore(SpawnPosition p_spawnPosition)
    {
        DefenceCore createdCore = GameManager.Object.SpawnCore();
        createdCore.transform.position = p_spawnPosition.transform.position;

        DefenceCoreData TestCoreData = new DefenceCoreData(50);

        createdCore.Init(TestCoreData);
        _targetDict.Add(createdCore.gameObject, createdCore);

        return createdCore;
    }



    public IDamagable GetTargetFromDictionary(GameObject p_gameObject)
    {
        if (_targetDict.TryGetValue(p_gameObject, out IDamagable p_target))
        {
            return p_target;
        }
        return null;
    }


    public static bool IsGameEnd()
    {
        if (_playerCore.CurHealth <= 0 || _enemyCore.CurHealth <= 0)
        {
            return true;
        }
        return false;
    }
}
