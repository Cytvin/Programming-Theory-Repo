using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    private List<GameObject> _buyableWeapons;

    private void Start()
    {
        InitializeBuyableWeaponsList();
    }

    public void BuyWeapon()
    {
        if (_buyableWeapons.Count == 0)
        {
            return;
        }

        _buyableWeapons[0].SetActive(true);
        _buyableWeapons[0].transform.parent = _player.transform;

        _player.AddWeapon(_buyableWeapons[0].GetComponent<Weapon>());
        _buyableWeapons.Remove(_buyableWeapons[0]);
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
