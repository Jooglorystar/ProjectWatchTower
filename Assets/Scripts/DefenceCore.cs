using UnityEngine;
using UnityEngine.UI;

public class DefenceCoreData
{
    public int MaxHealth;

    public DefenceCoreData(int p_value)
    {
        MaxHealth = p_value;
    }
}

public class DefenceCore : MonoBehaviour, IDamagable
{
    private int _curHealth;

    public int CurHealth => _curHealth;
    private DefenceCoreData _data;

    [SerializeField] private Image _healthBar;

    private void OnEnable()
    {
    }

    public void Init(DefenceCoreData p_data)
    {
        _data = p_data;

        _curHealth = _data.MaxHealth;
        _healthBar.fillAmount = _curHealth / _data.MaxHealth;
    }

    public bool Damaged(int p_value)
    {
        _curHealth -= p_value;
        _healthBar.fillAmount = (float)_curHealth / _data.MaxHealth;
        if (_curHealth <= 0)
        {
            StageManager.Instance.ActivateEndPanel();
            return true;
        }
        return false;
    }
}