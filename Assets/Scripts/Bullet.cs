using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject _target;
    private int _damage = 0;

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(_target.transform.position);
        transform.Rotate(-90, 0, 0);

        transform.Translate(Vector3.down * 10f * Time.deltaTime);
    }

    // ENCAPSULATION
    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    // ENCAPSULATION
    public void SetDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.ApplyDamage(_damage);
        }

        Destroy(gameObject);
    }
}
