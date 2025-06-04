using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private SpawnPosition _playerSpawnPosition;
    [SerializeField] private SpawnPosition _enemySpawnPosition;

    [SerializeField] private int _playerCount;
    [SerializeField] private int _enemyCount;

    private List<Unit> _playerUnits = new List<Unit>();
    private List<Unit> _enemyUnits = new List<Unit>();

    public SpawnPosition SpawnPos => _playerSpawnPosition; 
    public IReadOnlyList<Unit> PlayerUnits => _playerUnits;
    public IReadOnlyList<Unit> EnemyUnits => _enemyUnits;

    private void Awake()
    {
        ResetUnitList(_playerUnits);
        ResetUnitList(_enemyUnits);
    }

    private Unit Spawn(SpawnPosition p_spawnPosition)
    {
        Unit unit = GameManager.Object.SpawnUnit();
        unit.gameObject.transform.position = p_spawnPosition.transform.position;
        unit.Movement.SetDirection(p_spawnPosition.UnitDirection);

        return unit;
    }

    public void SpawnPlayerUnit()
    {
        Unit unit = Spawn(_playerSpawnPosition);
        unit.SetColor(true);
        _playerUnits.Add(unit);
        unit.gameObject.name = $"PlayerUnit{_playerUnits.Count}";
        _playerCount = _playerUnits.Count;
    }

    public void SpawnEnemyUnit()
    {
        Unit unit = Spawn(_enemySpawnPosition);
        unit.SetColor(false);
        _enemyUnits.Add(unit);
        unit.gameObject.name = $"EnemyUnit{_enemyUnits.Count}";
        _enemyCount = _enemyUnits.Count;
    }

    public void DespawnPlayerUnit(Unit p_unit)
    {
        if (_playerUnits.Contains(p_unit))
        {
            _playerUnits.Remove(p_unit);
        }
    }

    private Unit GetUnit(List<Unit> p_unitList, Unit p_unit)
    {
        if (p_unitList.Contains(p_unit))
        {
            return p_unit;
        }
        else
        {
            return null;
        }
    }

    public Unit GetEnemyUnit(Unit p_unit)
    {
        return GetUnit(_enemyUnits, p_unit);
    }

    public Unit GetPlayerUnit(Unit p_unit)
    {
        return GetUnit(_playerUnits, p_unit);
    }


    private void ResetUnitList(List<Unit> p_unitList)
    {
        if(p_unitList == null)
        {
            p_unitList = new List<Unit>();
        }
        else
        {
            p_unitList.Clear();
        }
    }
}
