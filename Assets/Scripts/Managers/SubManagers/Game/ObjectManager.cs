using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private string _unitObjectPath;

    private Unit _cacheUnit;

    public Unit SpawnUnit()
    {
        if (_cacheUnit == null)
        {
            _cacheUnit = Resources.Load<Unit>(_unitObjectPath);
        }

        return Instantiate(_cacheUnit);
    }
}
