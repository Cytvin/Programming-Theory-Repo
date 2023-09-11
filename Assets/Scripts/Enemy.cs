using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    private Vector3 _playerPosition;
    private int _award = 5;

    public event Action<int> IsDead;

    void Update()
    {
        transform.LookAt( _playerPosition);
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
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

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        _playerPosition = playerPosition;
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
