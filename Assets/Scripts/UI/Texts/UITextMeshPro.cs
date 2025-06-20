using TMPro;
using UnityEngine;

public class UITextMeshPro : MonoBehaviour
{
    protected TextMeshProUGUI tmp;

    protected virtual void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }
    
    public void RefreshText(string p_string)
    {
        tmp.text = p_string;
    }

    public void RefreshText(int p_value)
    {
        tmp.text = p_value.ToString();
    }
}
