using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var weapon in _weapons) 
        {
            weapon.Use();
        }
    }
}
