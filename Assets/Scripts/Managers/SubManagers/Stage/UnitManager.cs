using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private List<Unit> _playerUnits = new List<Unit>();
    private List<Unit> _enemyUnits = new List<Unit>();

    public IReadOnlyList<Unit> PlayerUnits => _playerUnits;
    public IReadOnlyList<Unit> EnemyUnits => _enemyUnits;

    [SerializeField] private UnitData[] _unitDatas;
    private Dictionary<int, UnitData> _unitDataDic;

    private void Awake()
    {
        ResetUnitList(_playerUnits);
        ResetUnitList(_enemyUnits);
        CreateData();
    }

    private void CreateData()
    {
        _unitDataDic = new Dictionary<int, UnitData>();

        foreach(UnitData data in _unitDatas)
        {
            _unitDataDic.Add(data.UnitID, data);
        }
    }

    public void TrySpawn(int p_unitID)
    {
        if (CanSpawn(p_unitID))
        {
            SpawnSuccess(p_unitID);
        }
        else
        {
            SpawnFail();
        }
    }

    private void SpawnSuccess(int p_unitID)
    {
        SpawnPlayerUnit();
        StageManager.ResourceBank.UsePlayerResource(_unitDataDic[p_unitID].UnitCost);
    }

    private void SpawnFail()
    {
        Debug.Log("Spawn Fail!");
    }

    private bool CanSpawn(int p_unitID)
    {
        if (StageManager.ResourceBank.Player > _unitDataDic[p_unitID].UnitCost)
        {
            return true;
        }

        return false;
    }

    private Unit Spawn(SpawnPosition p_spawnPosition, UnitData p_unitData)
    {
        Unit unit = GameManager.Object.SpawnUnit();
        unit.gameObject.transform.position = p_spawnPosition.transform.position;
        unit.Movement.SetDirection(p_spawnPosition.UnitDirection);

        unit.SetUnitData(p_unitData);

        StageManager.Instance.TargetDict.Add(unit.gameObject, unit);

        return unit;
    }

    public void SpawnPlayerUnit()
    {
        Unit unit = Spawn(StageManager.Instance.PlayerSpawnPosition, _unitDatas[0]);
        unit.SetColor(true);

        _playerUnits.Add(unit);

        unit.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void SpawnEnemyUnit()
    {
        Unit unit = Spawn(StageManager.Instance.EnemySpawnPosition, _unitDatas[1]);
        unit.SetColor(false);

        _enemyUnits.Add(unit);

        unit.gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    public void Despawn(Unit p_unit)
    {
        if (_playerUnits.Contains(p_unit))
        {
            _playerUnits.Remove(p_unit);
        }
        else if(_enemyUnits.Contains(p_unit))
        {
            _enemyUnits.Remove(p_unit);
        }
        else
        {
            Debug.Log("SomethingWrong");
        }

        if(StageManager.Instance.TargetDict.ContainsKey(p_unit.gameObject))
        {
            StageManager.Instance.TargetDict.Remove(p_unit.gameObject);
        }

        GameManager.Object.DespawnUnit(p_unit);
    }

    public bool IsEnemyUnitEmpty(Unit p_unit)
    {
        if(_enemyUnits.Contains(p_unit) && _playerUnits.Count <= 0)
        {
            return true;
        }
        else if(_playerUnits.Contains(p_unit) && _enemyUnits.Count <= 0)
        {
            return true;
        }

        return false;
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
