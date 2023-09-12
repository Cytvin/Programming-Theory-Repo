using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void AddListener(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }

    public void RemoveListener(UnityAction action) 
    {
        _button.onClick.RemoveListener(action);
    }

    public void SetTitle(string title)
    {
        TextMeshProUGUI titleText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        titleText.text = title;
    }

    public void SetPrice(string price)
    {
        TextMeshProUGUI priceText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        priceText.text = price;
    }

    public void Disable()
    {
        _button.enabled = false;
    }
}
