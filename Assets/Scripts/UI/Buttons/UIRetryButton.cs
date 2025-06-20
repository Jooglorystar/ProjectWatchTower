public class UIRetryButton : UIButton
{
    protected override void Awake()
    {
        base.Awake();

        button.onClick.AddListener(GameManager.Instance.StartStage);
    }
}
