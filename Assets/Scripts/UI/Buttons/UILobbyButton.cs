using UnityEngine;

public class UILobbyButton : UIButton
{
    protected override void Awake()
    {
        base.Awake();

        button.onClick.AddListener(GameManager.Instance.GoToLobby);
    }
}
