using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    private Vector3 _playerPosition;
    private float _movementSpeed = 1;
    private int _award = 5;

    public event Action<int> IsDead;

    void Update()
    {
        transform.LookAt( _playerPosition);
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            IsDead?.Invoke(_award);
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        _movementSpeed = speed;
    }

    public void SlowDown(float slowForce, float duration)
    {
        _movementSpeed -= slowForce;

        StartCoroutine(CancelSlowDown(slowForce ,duration));
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        _playerPosition = playerPosition;
    }

    private IEnumerator CancelSlowDown(float slowForce, float duration)
    {
        yield return new WaitForSeconds(duration);

        _movementSpeed += slowForce;
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
