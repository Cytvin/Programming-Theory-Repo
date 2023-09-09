using UnityEngine;

public class WaveWeapon : Weapon
{
    [SerializeField] private GameObject _wavePrefab;
    private GameObject _lastWave;
    private float _nextShoot = 0;

    public override void Use()
    {
        if (_nextShoot > Time.time)
        {
            return;
        }

        DestroyLastWave();
        SpawnNewWave();
        _nextShoot = Time.time + AttackSpeed;
    }

    private void SpawnNewWave()
    {
        _lastWave = Instantiate(_wavePrefab, transform.position, _wavePrefab.transform.rotation);
        Wave wave = _lastWave.GetComponent<Wave>();
        wave.SetDamage(Damage);
    }

    private void DestroyLastWave()
    {
        Destroy(_lastWave);
    }
}
