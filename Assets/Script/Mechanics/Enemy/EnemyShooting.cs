using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public EnemyData data;
    public Transform shootPoint;
    private float shootInterval = 5f;
    private float range = 100f;
    public LayerMask hitLayers;

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

        Vector3 direction = (player.position - shootPoint.position).normalized;

        if (Physics.Raycast(shootPoint.position, direction, out RaycastHit hit, range, hitLayers))
        {
            Debug.DrawLine(shootPoint.position, hit.point, Color.red, 0.2f);

            if (hit.collider.TryGetComponent<PlayerHealth>(out var playerHealth))
            {
                playerHealth.TakeDamage(data.bulletDamage);
                Debug.Log("Player hit"); 
            }
        }
        else
        {
            Debug.DrawLine(shootPoint.position, shootPoint.position + direction * range, Color.yellow, 0.2f);
            Debug.Log("Player missed");
        }
    }
}
