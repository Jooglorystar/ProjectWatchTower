public class UIPlayerResourceText : UITextMeshPro
{

    private void OnEnable()
    {
        StageManager.Instance.ResourceBank.OnPlayerValueChanged += RefreshText;
    }

    private void OnDisable()
    {
        StageManager.Instance.ResourceBank.OnPlayerValueChanged -= RefreshText;
    }
}
