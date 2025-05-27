using UnityEngine;

public class ObjectManager : SingletonObject<ObjectManager>
{
    [SerializeField] private string _unitObjectPath;

    private Unit _cacheUnit;

    protected override void Awake()
    {
        base.Awake();

        _cacheUnit = Resources.Load<Unit>(_unitObjectPath);
    }

    public Unit SpawnUnit()
    {
        Instantiate(_cacheUnit.gameObject);
        return _cacheUnit;
    }
}
