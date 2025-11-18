using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public InGameData data;
    public float reloadTime = 1f;
    bool isReloading;
    public float range = 100f;
    void Start()
    {
        AmmoUIManager.Instance.UpdateAmmo((int)data.ammo);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && data.ammo > 0 && !isReloading)
            Shoot();

        if ((data.ammo == 0 && !isReloading) || Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
    }

    void Shoot()
    {
        PlayerAnimationController.Instance.SwitchWeapon(WeaponType.Gun);
        PlayerAnimationController.Instance.TriggerAnimation(WeaponType.Gun, "Shoot");
        AudioManager.Instance.PlaySFX(AudioManager.Instance.attackSound);
         data.ammo--;
        AmmoUIManager.Instance.UpdateAmmo((int)data.ammo);
        GameStatsManager.Instance.Shoot();

        // ---- HITSCAN DAMAGE ---- //
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 0.25f);

            // EXACT SAME DAMAGE LOGIC AS BULLET.cs
            if (hit.collider.TryGetComponent<PlayerHealth>(out var player))
                player.TakeDamage(data.bulletDamage);

            if (hit.collider.TryGetComponent<EnemyHealth>(out var enemy))
                enemy.TakeDamage(data.bulletDamage);

            // Optional hit effect:
            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.GetPoint(range), Color.yellow, 0.25f);
        }
    }

    System.Collections.IEnumerator Reload()
    {
        PlayerAnimationController.Instance.SwitchWeapon(WeaponType.Gun);
        PlayerAnimationController.Instance.TriggerAnimation(WeaponType.Gun, "Reload");
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        data.ammo = 5;
        AmmoUIManager.Instance.UpdateAmmo((int)data.ammo);

        isReloading = false;
    }
}
