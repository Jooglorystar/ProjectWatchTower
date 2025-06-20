using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private string _unitObjectPath;
    [SerializeField] private string _coreObjectPath;

    private Unit _cacheUnit;
    private DefenceCore _cacheCore;
    public Unit SpawnUnit()
    {
        if (_cacheUnit == null)
        {
            _cacheUnit = Resources.Load<Unit>(_unitObjectPath);
        }

        return Instantiate(_cacheUnit);
    }

    public void DespawnUnit(Unit p_unit)
    {
        p_unit.gameObject.SetActive(false);
    }

    public DefenceCore SpawnCore()
    {
        if (_cacheCore == null)
        {
            _cacheCore = Resources.Load<DefenceCore>(_coreObjectPath);
        }

        return Instantiate(_cacheCore);
    }
}