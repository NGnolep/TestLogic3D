using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text enemiesDefeatedText;
    public TMP_Text scoreText;
    public TMP_Text qUsedText;
    public TMP_Text eUsedText;
    public TMP_Text shotsFiredText;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        enemiesDefeatedText.text = $"Enemies Defeated: {GameStatsManager.Instance.enemiesDefeated}";
        scoreText.text = $"Score: {GameStatsManager.Instance.score}";
        qUsedText.text = $"Q Used: {GameStatsManager.Instance.qUsed}";
        eUsedText.text = $"E Used: {GameStatsManager.Instance.eUsed}";
        shotsFiredText.text = $"Shots Fired: {GameStatsManager.Instance.shotsFired}";

        // Pause the game
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ReloadScene()
    {
        Time.timeScale = 1f;
        GameStatsManager.Instance.ResetStats();
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (FadeController.Instance != null)
            FadeController.Instance.FadeOutAndLoad(currentScene);
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        GameStatsManager.Instance.ResetStats();
        if (FadeController.Instance != null)
            FadeController.Instance.FadeOutAndLoad("MainMenu");
        else
            SceneManager.LoadScene("MainMenu");
    }
}
