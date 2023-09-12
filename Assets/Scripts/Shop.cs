using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private List<GameObject> _buyableWeapons;
    private int _weaponCoast = 5;

    public event Action<int> WeaponCoastChanged;
    public event Action<int> WeaponsCountChanged;

    public int WeaponCoast => _weaponCoast; 
    public int WeaponCount => _buyableWeapons.Count;

    private void Start()
    {
        InitializeBuyableWeaponsList();
    }

    public Weapon BuyWeapon(Transform playerTransform)
    {
        _buyableWeapons[0].SetActive(true);
        _buyableWeapons[0].transform.parent = playerTransform.transform;

        Weapon weapon = _buyableWeapons[0].GetComponent<Weapon>();

        _buyableWeapons.Remove(_buyableWeapons[0]);

        ChangeWeaponCoast();

        WeaponsCountChanged?.Invoke(_buyableWeapons.Count);
        return weapon;
    }

    private void ChangeWeaponCoast()
    {
        _weaponCoast += 100;
        WeaponCoastChanged?.Invoke(_weaponCoast);
    }

    private void InitializeBuyableWeaponsList()
    {
        _buyableWeapons = new List<GameObject>();

        foreach (Transform transform in transform)
        {
            _buyableWeapons.Add(transform.gameObject);
        }
    }
}
