using UnityEngine;

public class UISpawnButton : UIButton
{
    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        button.onClick.AddListener(() => UnitManager.Instance.TrySpawn(100001));
    }
}
