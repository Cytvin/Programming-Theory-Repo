using UnityEngine;

public class ShopPresenter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private Shop _shop;

    private void Start()
    {
        _buyButton.AddListener(BuyWeapon);
        _buyButton.SetPrice(_shop.WeaponCoast.ToString());
        _shop.WeaponCoastChanged += OnWeaponCoastChanged;
        _shop.WeaponsCountChanged += OnWeaponsCountChanged;
    }

    private void OnDestroy()
    {
        _buyButton.RemoveListener(BuyWeapon);
        _shop.WeaponCoastChanged -= OnWeaponCoastChanged;
        _shop.WeaponsCountChanged -= OnWeaponsCountChanged;
    }

    public void BuyWeapon()
    {
        if (_player.TryBuy(_shop.WeaponCoast) == false)
        {
            return;
        }

        _player.Buy(_shop.WeaponCoast);
        _player.AddWeapon(_shop.BuyWeapon(_player.transform));
    }

    private void OnWeaponCoastChanged(int weaponCoast)
    {
        _buyButton.SetPrice(weaponCoast.ToString());
    }

    private void OnWeaponsCountChanged(int weaponsCount)
    {
        if (weaponsCount > 0)
        {
            return;
        }

        _buyButton.Disable();
    }
}
