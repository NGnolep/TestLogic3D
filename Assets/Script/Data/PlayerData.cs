using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public float maxHP = 100;
    public float bulletDamage = 20;
}
