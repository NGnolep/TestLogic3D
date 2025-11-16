using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealSkill : MonoBehaviour
{
    public PlayerHealth health;

    public float healPerSecond = 10;
    public float duration = 5;
    public float cooldown = 10;

    public bool active;
    public bool onCooldown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !active && !onCooldown)
            StartCoroutine(HealRoutine());
    }

    System.Collections.IEnumerator HealRoutine()
    {
        active = true;
        onCooldown = true;

        float timer = 0;

        while (timer < duration)
        {
            health.Heal(healPerSecond);
            timer += 1;
            yield return new WaitForSeconds(1);
        }

        active = false;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}
