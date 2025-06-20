public class UIPlayerResourceText : UITextMeshPro
{

    private void Start()
    {
        StageManager.Instance.ResourceBank.OnPlayerValueChanged += RefreshText;
    }
}
