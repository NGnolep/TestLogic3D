using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    public UnityEvent<float, float> OnHPChanged;

    public EnemyData data;
    public InGameData dataScore;
    float currentHP;

    void Start()
    {
        currentHP = data.maxHP;
        OnHPChanged.Invoke(currentHP, data.maxHP);
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, data.maxHP);

        OnHPChanged.Invoke(currentHP, data.maxHP);

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        StartCoroutine(DieRoutine());
    }

    IEnumerator DieRoutine()
    {
        EnemyAnimationController.Instance.TriggerAnimation("Dead");
        AudioManager.Instance.PlaySFX(AudioManager.Instance.deathSound);
        GameStatsManager.Instance.AddEnemyDefeated();
        GameStatsManager.Instance.AddScore(dataScore.killScore);

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
