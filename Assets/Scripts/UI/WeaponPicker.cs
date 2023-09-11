using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            Button button = Instantiate(_buttonPrefab, transform).GetComponent<Button>();

            TextMeshProUGUI buttonText = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            buttonText.SetText($"Upgrade\n{weapon.GetWeaponName()}");

            button.onClick.AddListener(() =>
            {
                if (_player.TryGetMoney(weapon.UpgradeCoast))
                {
                    weapon.Upgrade();
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
