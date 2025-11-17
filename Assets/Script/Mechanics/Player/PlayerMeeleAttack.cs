using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeeleAttack : MonoBehaviour
{
    public float damage = 40;
    public float range = 5f;
    public PlayerUltimate ultimate;
    void Update()
    {
        if (ultimate.active && Input.GetMouseButtonDown(0))
        {
            DoMelee();
        }
    }
    public void DoMelee()
    {
        PlayerAnimationController.Instance.SwitchWeapon(WeaponType.Melee);
        PlayerAnimationController.Instance.TriggerAnimation(WeaponType.Melee, "attack");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.collider.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
