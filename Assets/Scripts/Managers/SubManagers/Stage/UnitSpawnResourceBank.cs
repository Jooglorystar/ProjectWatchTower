using UnityEngine;

public class UnitSpawnResourceBank : MonoBehaviour
{
    private int _playerValue;
    private int _enemyValue;

    public int Player => _playerValue;
    public int Enemy => _enemyValue;

    public void Init()
    {
        _playerValue = 100;
        _enemyValue = 100;
    }

    public void UsePlayerResource(int p_value)
    {
        _playerValue -= p_value;
    }

    public void UseEnemyResource(int p_value)
    {
        _enemyValue -= p_value;
    }
}
