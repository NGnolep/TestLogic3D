using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName = "Outlaw";
    public float maxHP = 100;
    public float bulletDamage = 20;
}
