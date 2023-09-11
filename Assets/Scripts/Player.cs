using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    private int _money;

    public event Action<List<Weapon>> WeaponsListChanged;
    public event Action<int> MoneyCountChanged;

    private void Update()
    {
        foreach (var weapon in _weapons) 
        {
            // POLYMORPHISM
            weapon.Use();
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
        WeaponsListChanged?.Invoke(_weapons);
    }

    public bool TryGetMoney(int money)
    {
        if (_money - money < 0)
        {
            return false;
        }

        _money -= money;
        MoneyCountChanged?.Invoke(_money);
        return true;
    }

    public void KillEnemy(int money)
    {
        _money += money;
        MoneyCountChanged?.Invoke(_money);
    }
}
