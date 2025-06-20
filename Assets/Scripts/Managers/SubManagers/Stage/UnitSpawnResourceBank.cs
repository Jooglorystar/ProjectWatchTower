using System;
using UnityEngine;

public class UnitSpawnResourceBank : MonoBehaviour
{
    private int _playerValue;
    private int _enemyValue;

    private int _playerValueMax = 1000;
    private int _enemyValueMax = 1000;
    private int _startValue = 100;

    public int Player => _playerValue;
    public int Enemy => _enemyValue;

    [SerializeField] private UIPlayerResourceText playervalueText;

    public event Action<int> OnPlayerValueChanged;

    private void Update()
    {
        ChargePlayerResource();
        ChargeEnemyResource();
    }

    public void Init()
    {
        _playerValue = _startValue;
        _enemyValue = _startValue;
        RaisePlayerValueChanged(_playerValue);
    }

    #region Player
    public void UsePlayerResource(int p_value)
    {
        _playerValue = Mathf.Max(_playerValue - p_value, 0);
        RaisePlayerValueChanged(_playerValue);
    }

    public void GainPlayerResource(int p_value)
    {
        _playerValue = Mathf.Min(_playerValue + p_value, _playerValueMax);
        RaisePlayerValueChanged(_playerValue);
    }

    private float _chargeTimer = 0;
    private float _chargeTime = 2;
    private int _chargeValue = 10;
    private void ChargePlayerResource()
    {
        _chargeTimer += Time.deltaTime;

        if (_chargeTimer >= _chargeTime)
        {
            GainPlayerResource(_chargeValue);
            _chargeTimer = 0f;
        }
    }

    private void RaisePlayerValueChanged(int p_value)
    {
        OnPlayerValueChanged?.Invoke(p_value);
    }
    #endregion


    #region Enemy
    public void UseEnemyResource(int p_value)
    {
        _enemyValue = Mathf.Max(_enemyValue - p_value, 0);
    }

    public void GainEnemyResource(int p_value)
    {
        _enemyValue = Mathf.Min(_enemyValue + p_value, _enemyValueMax);
    }

    private void ChargeEnemyResource()
    {
        // TODO: StageEnemy 데이터를 만들고 그에 따라 충전될 예정
    }
    #endregion
}
