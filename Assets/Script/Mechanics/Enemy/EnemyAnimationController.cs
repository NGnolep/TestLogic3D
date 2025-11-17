using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public static EnemyAnimationController Instance;

    public Animator enemyAnimator;

    void Awake()
    {
        // Make this a singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerAnimation(string triggerName)
    {
        if (enemyAnimator != null)
        {
            enemyAnimator.SetTrigger(triggerName);
        }
        else
        {
            Debug.LogWarning("Player Animator not assigned in AnimationController!");
        }
    }
}
