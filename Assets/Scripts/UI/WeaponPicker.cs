using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _buttonPrefab;

    private void Start()
    {
        _player.WeaponsListChanged += DisplayWeapomButtons;
    }

    private void OnDestroy()
    {
        _player.WeaponsListChanged -= DisplayWeapomButtons;
    }

    private void DisplayWeapomButtons(IEnumerable<Weapon> weapons)
    {
        ClearButtonList();

        foreach (Weapon weapon in weapons) 
        {
            BuyButton button = Instantiate(_buttonPrefab, transform).GetComponent<BuyButton>();

            button.SetTitle(weapon.GetWeaponName());
            button.SetPrice(weapon.UpgradePrice.ToString());

            button.AddListener(() =>
            {
                if (_player.TryBuy(weapon.UpgradePrice))
                {
                    _player.Buy(weapon.UpgradePrice);
                    weapon.Upgrade();

                    button.SetPrice(weapon.UpgradePrice.ToString());
                }

                WeaponDisplayer.Instance.DisplayWeapon(weapon.GetWeaponName(), weapon.GetWeaponData());
            });
        }
    }

    private void ClearButtonList()
    {
        foreach (Transform button in transform)
        {
            Destroy(button.gameObject);
        }
    }
}
