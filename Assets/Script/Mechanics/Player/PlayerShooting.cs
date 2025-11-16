using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public int ammo = 5;
    public float reloadTime = 1f;
    bool isReloading;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0 && !isReloading)
            Shoot();

        if (ammo == 0 && !isReloading)
            StartCoroutine(Reload());
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            targetPoint = hit.point; 
        }
        else
        {
            targetPoint = ray.GetPoint(100f); 
        }

    
        Vector3 direction = (targetPoint - shootPoint.position).normalized;
        bullet.transform.forward = direction;

        ammo--;
        AmmoUIManager.Instance.UpdateAmmo(ammo);
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammo = 5;
        AmmoUIManager.Instance.UpdateAmmo(ammo);
        isReloading = false;
    }
}
