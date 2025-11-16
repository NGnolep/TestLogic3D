using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    int score;

    void Awake() => Instance = this;

    public void AddScore(int amount)
    {
        score += amount;
    }

    public int GetScore() => score;
}
