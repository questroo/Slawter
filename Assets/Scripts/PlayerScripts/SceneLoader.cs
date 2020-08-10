using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void LoadTestScene()
    {
        SceneManager.LoadScene("Test");
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
