using System.Collections.Generic;
using UnityEngine;

public class UnitManager : SingletonObject<UnitManager>
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _unit;

    private List<Unit> _playerUnits;

    public Transform SpawnPos { get { return _spawnPosition; } }
    public List<Unit> PlayerUnits { get { return _playerUnits; } }

    public void SpawnPlayerUnit()
    {
        GameObject unit = Instantiate(_unit);

        unit.transform.position = _spawnPosition.position;
    }
}
