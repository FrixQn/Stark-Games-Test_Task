using UnityEngine.UI;
using UnityEngine;

public class HelthValue : MonoBehaviour
{
    private Text HelthText => GetComponent<Text>();

    public void UpdateValue(int newValue)
    {
        HelthText.text = newValue.ToString();
    }

    public void Hide()
    {
        HelthText.transform.parent.gameObject.SetActive(false);
    }
}
