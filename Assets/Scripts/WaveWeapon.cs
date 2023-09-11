using UnityEngine;

// INHERITANCE
public class WaveWeapon : Weapon
{
    [SerializeField] private GameObject _wavePrefab;
    private Wave _wave;
    private bool _canShoot = true;

    private void Awake()
    {
        GameObject wave = Instantiate(_wavePrefab, transform.position, _wavePrefab.transform.rotation);
        _wave = wave.GetComponent<Wave>();
        _wave.SetMaxScale(AttackRange * 2);
        _wave.ScaleCompleted += OnCanShoot;
    }

    private void OnDestroy()
    {
        _wave.ScaleCompleted -= OnCanShoot;
    }

    public override void Use()
    {
        if (_canShoot == false)
        {
            return;
        }

        _wave.StartWave(Damage);
        _canShoot = false;
    }

    public override void Upgrade()
    {
        SetDamage(Damage + 2);
        SetAttackRange(AttackRange + 0.5f);
        SetUpgradeCoast(UpgradeCoast + 15);
    }

    public override string GetWeaponName()
    {
        return "Wave Weapon";
    }

    public override string GetWeaponData()
    {
        return $"Damage: {Damage}\nAttack Range: {AttackRange}\nUpgrade Coast: {UpgradeCoast}";
    }

    private void OnCanShoot(bool canShoot)
    {
        _canShoot = canShoot;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
