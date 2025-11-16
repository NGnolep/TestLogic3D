using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBarSpawner : MonoBehaviour
{
    public GameObject hpBarPrefab;

    void Start()
    {
        EnemyHealth health = GetComponent<EnemyHealth>();

        GameObject bar = Instantiate(hpBarPrefab);
        EnemyHPBar barScript = bar.GetComponent<EnemyHPBar>();

        barScript.target = transform;  // << THE ENEMY'S TRANSFORM
        health.OnHPChanged.AddListener(barScript.UpdateHP);
    }
}
