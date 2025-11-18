using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InGameData", menuName = "Game Data/In Game Data")]
public class InGameData : ScriptableObject
{
    public float bulletDamage = 20;
    public float ammo = 5;
    public int killScore = 2000;
}
