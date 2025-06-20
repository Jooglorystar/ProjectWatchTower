using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private UnitData[] _unitDatas;
    private Dictionary<int, UnitData> _unitDataDic;

    private void Awake()
    {
        CreateData();
    }

    private void CreateData()
    {
        _unitDataDic = new Dictionary<int, UnitData>();

        foreach (UnitData data in _unitDatas)
        {
            _unitDataDic.Add(data.UnitID, data);
        }
    }

    public UnitData GetUnitData(int p_id)
    {
        if(_unitDataDic.ContainsKey(p_id))
        {
            return _unitDataDic[p_id];
        }
        return null;
    }
}