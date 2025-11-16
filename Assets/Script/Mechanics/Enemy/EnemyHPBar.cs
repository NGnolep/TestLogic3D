using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHPBar : MonoBehaviour
{
    public Slider slider;
    public Transform target;  // enemy head
    public Vector3 offset = new Vector3(0, 2f, 0);

    void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Follow enemy
        transform.position = target.position + offset;

        // Face the camera
        transform.LookAt(Camera.main.transform);
    }

    public void UpdateHP(float currentHP, float maxHP)
    {
        slider.maxValue = maxHP;
        slider.value = currentHP;
    }
}
