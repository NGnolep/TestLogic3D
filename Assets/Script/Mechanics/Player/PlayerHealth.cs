using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerHealth : MonoBehaviour
{
    public UnityEvent<float, float> OnHPChanged = new UnityEvent<float, float>();

    public PlayerData data;
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
        Debug.Log("Player took damage");
        OnHPChanged.Invoke(currentHP, data.maxHP);

    }

    public void Heal(float amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, data.maxHP);

        OnHPChanged.Invoke(currentHP, data.maxHP);
    }

    public void SetMaxHP(float newHP)
    {
        data.maxHP = newHP;
        currentHP = newHP;
        OnHPChanged.Invoke(currentHP, data.maxHP);
    }
}
