using System;
using UnityEngine;

// INHERITANCE
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _attackRange = 5;
    [SerializeField] private int _upgradeCoast = 5;

    // ENCAPSULATION
    public int Damage => _damage;
    public float AttackRange => _attackRange;
    public int UpgradePrice => _upgradeCoast;

    // ENCAPSULATION
    public virtual void SetDamage(int damage)
    {
        _damage = damage;
    }
    // ENCAPSULATION
    public virtual void SetAttackRange(float attackRange)
    {
        _attackRange = Mathf.Round(attackRange * 100) * 0.01f;
    }

    public virtual void SetUpgradeCoast(int upgradeCoast)
    {
        _upgradeCoast = upgradeCoast;
    }

    public abstract void Use();

    public abstract void Upgrade();

    public abstract string GetWeaponName();

    public abstract string GetWeaponData();
}
