using System;
using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 0.1f;
    private int _damage = 0;
    private float _maxScale = 5;

    public Action<bool> ScaleCompleted;

    // ENCAPSULATION
    public int Damage => _damage;
    public float ScaleSpeed => _scaleSpeed;

    public void StartWave(int damage)
    {
        SetDamange(damage);
        StartCoroutine(IncreaseScale());
    }

    // ENCAPSULATION
    public void SetMaxScale(float attackRange)
    {
        _maxScale = attackRange;
    }

    private void SetDamange(int damage)
    {
        _damage = damage > 0 ? damage : damage * -1;
    }

    private void ResetLocalScale()
    {
        transform.localScale = Vector3.one;
    }

    // ABSTRACTION
    private IEnumerator IncreaseScale()
    {
        Vector3 currentScale = transform.localScale;

        while (currentScale.z <= _maxScale)
        {
            currentScale.x += _scaleSpeed;
            currentScale.y += _scaleSpeed;
            currentScale.z += _scaleSpeed;

            transform.localScale = currentScale;
            yield return new WaitForSeconds(0.03f);
        }

        ScaleCompleted?.Invoke(true);
        ResetLocalScale();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemy.ApplyDamage(Damage);

            enemy.SlowDown(0.4f, 2);
        }
    }
}
