using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void PauseButton()
    {
        TogglePause();
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f; 
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;  
            Cursor.visible = true;                   
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;                   
        }
    }

    public void ResumeButton()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }
    public void QuitButton()
    {
        Time.timeScale = 1f;
        if (FadeController.Instance != null)
            FadeController.Instance.FadeOutAndLoad("MainMenu");
        else
            SceneManager.LoadScene("MainMenu");

        Cursor.lockState = CursorLockMode.None;  
        Cursor.visible = true;
    }
}
