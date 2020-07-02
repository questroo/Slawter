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
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main");
    }
    //public void LoadLevelSelect()
    //{
    //    
    //}
}
