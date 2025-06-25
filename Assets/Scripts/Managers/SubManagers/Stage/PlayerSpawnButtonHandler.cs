using UnityEngine;

public class PlayerSpawnButtonHandler : MonoBehaviour
{
    [SerializeField] private UISpawnButton[] _spawnButtons;

    public void Init()
    {
        InsertUnitDataInButton();
    }

    private void InsertUnitDataInButton()
    {
        for (int i = 0; i < 6; i++)
        {
            _spawnButtons[i].SetSpawnData(GameManager.Instance.PlayerData.PlayerUnits[i]);
        }
    }
}