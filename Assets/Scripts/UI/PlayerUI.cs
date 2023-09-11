using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyCount;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.MoneyCountChanged += DisplayMoneyCount;
    }

    private void OnDestroy()
    {
        _player.MoneyCountChanged -= DisplayMoneyCount;
    }

    private void DisplayMoneyCount(int money)
    {
        _moneyCount.text = $"Money: {money}";
    }
}
