using UnityEngine;
using UnityEngine.UI;

public abstract class UIButton : MonoBehaviour
{
    protected Image image;
    protected Button button;

    protected virtual void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }
}

public class UIRetryButton : UIButton
{
    protected override void Awake()
    {
        base.Awake();

        button.onClick.AddListener(GameManager.Instance.StartStage);
    }
}
