using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootInterval = 5f;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        InvokeRepeating(nameof(ShootPlayer), shootInterval, shootInterval);
    }

    void ShootPlayer()
    {
        EnemyAnimationController.Instance.TriggerAnimation("fire");
        AudioManager.Instance.PlaySFX(AudioManager.Instance.attackSound);
        if (player == null) return;

        // calculate direction to player
        Vector3 dir = (player.position - shootPoint.position).normalized;

        // create bullet and aim it at player
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.LookRotation(dir));
    }
}
