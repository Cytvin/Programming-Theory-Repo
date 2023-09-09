using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 10;

    void Update()
    {
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
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
