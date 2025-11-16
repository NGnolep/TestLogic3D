using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UltiCooldownTextUI : MonoBehaviour
{
    public PlayerUltimate skill;    
    public TMP_Text cooldownText;  

    float timer;
    System.Reflection.FieldInfo onCooldownField;
    System.Reflection.FieldInfo cooldownField;

    void Start()
    {
        onCooldownField = skill.GetType().GetField("onCooldown");
        cooldownField   = skill.GetType().GetField("cooldown");

        cooldownText.text = "";
    }

    void Update()
    {
        bool onCooldown = (bool)onCooldownField.GetValue(skill);

        if (onCooldown)
        {
            float cooldownDur = (float)cooldownField.GetValue(skill);

            timer += Time.deltaTime;
            float remaining = cooldownDur - timer;

            if (remaining <= 0)
            {
                timer = 0;
                cooldownText.text = "";
                return;
            }

            cooldownText.text = Mathf.Ceil(remaining).ToString();
        }
        else
        {
            timer = 0;
            cooldownText.text = "";
        }
    }
}
