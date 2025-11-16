using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float damage = 20;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out var player))
            player.TakeDamage(damage);

        if (other.TryGetComponent<EnemyHealth>(out var enemy))
            enemy.TakeDamage(damage);

        Destroy(gameObject);
    }
}
