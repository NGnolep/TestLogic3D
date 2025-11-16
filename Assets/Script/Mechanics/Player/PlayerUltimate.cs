using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimate : MonoBehaviour
{
    public PlayerHealth health;
    public PlayerShooting shooter;
    public GameObject meleeMode;

    public float duration = 20;
    public float cooldown = 60;

    public bool active;
    public bool onCooldown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !active && !onCooldown)
            StartCoroutine(UltRoutine());
    }

    System.Collections.IEnumerator UltRoutine()
    {
        active = true;
        onCooldown = true;

        shooter.enabled = false;
        meleeMode.SetActive(true);

        health.SetMaxHP(200);

        yield return new WaitForSeconds(duration);

        shooter.enabled = true;
        meleeMode.SetActive(false);
        health.SetMaxHP(100);

        active = false;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}
