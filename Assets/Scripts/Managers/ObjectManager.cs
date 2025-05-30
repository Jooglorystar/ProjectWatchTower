using UnityEngine;

public class ObjectManager : SingletonObject<ObjectManager>
{
    [SerializeField] private string _unitObjectPath;

    private Unit _cacheUnit;

    protected override void Awake()
    {
        base.Awake();
    }

    public Unit SpawnUnit()
    {
        if (_cacheUnit == null)
        {
            _cacheUnit = Resources.Load<Unit>(_unitObjectPath);
        }

        Instantiate(_cacheUnit.gameObject);
        return _cacheUnit;
    }
}
