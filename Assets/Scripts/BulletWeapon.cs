using System.Linq;
using UnityEngine;

// INHERITANCE
public class BulletWeapon : Weapon
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _attackDelay = 3; 
    private float _nextShoot = 0;
    private GameObject _nearestEnemy = null;

    public override void Use()
    {
        if (_nextShoot > Time.time)
        {
            return;
        }

        if (_nearestEnemy != null)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation).GetComponent<Bullet>();

            bullet.SetDamage(Damage);
            bullet.SetTarget(_nearestEnemy);

            _nextShoot = Time.time + _attackDelay;
        }
        else
        {
            FindNearestEnemy();
        }
    }

    public override void Upgrade()
    {
        SetAttackDelay(_attackDelay - 0.1f);
        SetDamage(Damage + 1);
        SetAttackRange(AttackRange + 0.5f);
        SetUpgradeCoast(UpgradeCoast + 15);
    }

    public override string GetWeaponName()
    {
        return "Bullet Weapon";
    }

    public override string GetWeaponData()
    {
        return $"Damage: {Damage}\nAttack Range: {AttackRange}\nAttack Delay: {_attackDelay}\nUpgrade Coast: {UpgradeCoast}";
    }

    private void SetAttackDelay(float attackDelay)
    {
        if (attackDelay <= 0)
        {
            return;
        }

        _attackDelay = Mathf.Round(attackDelay * 10.0f) * 0.1f;
    }

    // ABSTRACTION
    private void FindNearestEnemy()
    {
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, AttackRange * 2);

        float distanceToNearestEnemy = AttackRange;

        foreach (Collider collider in hitCollider.Where(c => c.CompareTag("Enemy"))) 
        {
            Vector3 enemyPosition = collider.transform.position;
            float distanceToEnemy = Vector3.Distance(enemyPosition, transform.position);
            
            if (distanceToEnemy < distanceToNearestEnemy)
            {
                _nearestEnemy = collider.gameObject;
                distanceToNearestEnemy = distanceToEnemy;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
