using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject myCanvas;
    void Start()
    {
        myCanvas.SetActive(false);
    }

    private void TurnOnUI()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0.0f;
        myCanvas.SetActive(true);
    }

    private void OnEnable()
    {
        Health.OnPlayerDeath += TurnOnUI;
        NexusHealth.OnNexusDeath += TurnOnUI;
    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= TurnOnUI;
        NexusHealth.OnNexusDeath -= TurnOnUI;
    }
}
