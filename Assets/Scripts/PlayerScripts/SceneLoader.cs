using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadOptions()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Options");
    }
    public void LoadTestScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Test");
    }
    public void LoadGameOverScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameOver");
    }
    public void LoadGameScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenuScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
