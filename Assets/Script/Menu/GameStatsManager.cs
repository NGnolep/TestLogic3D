using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsManager : MonoBehaviour
{
    public static GameStatsManager Instance;

    public int enemiesDefeated { get; private set; }
    public int score { get; private set; }
    public int qUsed { get; private set; }
    public int eUsed { get; private set; }
    public int shotsFired { get; private set; }

    public int bestScore { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            bestScore = PlayerPrefs.GetInt("BestScore", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEnemyDefeated()
    {
        enemiesDefeated++;
    }

    public void AddScore(int amount)
    {
        score += amount;

        // Update best score
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public void UseQ() => qUsed++;
    public void UseE() => eUsed++;
    public void Shoot() => shotsFired++;

    public void ResetStats()
    {
        enemiesDefeated = 0;
        score = 0;
        qUsed = 0;
        eUsed = 0;
        shotsFired = 0;
    }
}
