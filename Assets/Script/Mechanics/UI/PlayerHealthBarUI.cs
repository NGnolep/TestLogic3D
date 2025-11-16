using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBarUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider hpSlider;

    void Start()
    {
        if (playerHealth == null)
            playerHealth = FindObjectOfType<PlayerHealth>();

        if (hpSlider == null)
            hpSlider = GetComponent<Slider>();

        // Subscribe to the HP change event
        playerHealth.OnHPChanged.AddListener(UpdateHP);
    }

    void UpdateHP(float currentHP, float maxHP)
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
    }
}
