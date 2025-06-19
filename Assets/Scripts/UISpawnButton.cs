using UnityEngine;

public class UISpawnButton : UIButton
{
    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        button.onClick.AddListener(() => StageManager.Unit.TrySpawn(100001));
    }
}
