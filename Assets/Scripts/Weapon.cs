using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _attackRange = 5;
    [SerializeField] private float _attackSpeed = 1;

    public int Damage => _damage;
    public float AttackRange => _attackRange;
    public float AttackSpeed => _attackSpeed;

    public virtual void SetDamage(int damage)
    {
        _damage = damage;
    }
    public virtual void SetAttackRange(float attackRange)
    {
        _attackRange = attackRange;
    }

    public virtual void Use()
    {

    }
}
