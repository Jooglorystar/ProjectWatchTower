using System.Collections.Generic;
using UnityEngine;

public class UnitManager : SingletonObject<UnitManager>
{
    [SerializeField] private Transform _spawnPosition;

    private List<Unit> _playerUnits;

    public Transform SpawnPos => _spawnPosition; 
    public IReadOnlyList<Unit> PlayerUnits => _playerUnits;

    protected override void Awake()
    {
        base.Awake();

        _playerUnits = new List<Unit>();
    }

    public void SpawnPlayerUnit()
    {
        Unit unit = ObjectManager.Instance.SpawnUnit();
        _playerUnits.Add(unit);
        unit.transform.position = _spawnPosition.position;
    }

    public void DespawnPlayerUnit(Unit p_unit)
    {
        if (_playerUnits.Contains(p_unit))
        {
            _playerUnits.Remove(p_unit);
        }
    }
}
