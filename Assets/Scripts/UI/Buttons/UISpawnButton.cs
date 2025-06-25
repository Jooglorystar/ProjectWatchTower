using UnityEngine;
using UnityEngine.UI;

public class UISpawnButton : UIButton
{
    [SerializeField] private Image p_unitIcon;

    protected override void Awake()
    {
        base.Awake();

    }

    public void SetSpawnData(int p_unitID)
    {
        if (p_unitID > 0)
        {
            EnableSpawnButton(p_unitID);
        }
        else
        {
            DisableSpawnButton();
        }
    }

    private void EnableSpawnButton(int p_unitID)
    {
        p_unitIcon.enabled = true;
        button.interactable = true;
        button.onClick.AddListener(() => UnitManager.Instance.TrySpawn(p_unitID));
        // TODO: Resources���� �̹����� �ҷ����� ������� ������ ��.
        // p_unitIcon.sprite = ;
    }

    private void DisableSpawnButton()
    {
        p_unitIcon.enabled = false;
        button.interactable = false;
    }
}
