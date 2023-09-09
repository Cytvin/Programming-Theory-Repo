using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 0.1f;
    private int _damage = 0;

    public int Damage => _damage;

    void Start()
    {
        StartCoroutine(IncreaseScale());
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    private IEnumerator IncreaseScale()
    {
        Vector3 scale = transform.localScale;

        while (scale.y < 15)
        {
            scale.x += _scaleSpeed;
            scale.y += _scaleSpeed;
            scale.z += _scaleSpeed;

            transform.localScale = scale;
            yield return new WaitForSeconds(0.03f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemy.ApplyDamage(Damage);
        }
    }
}
