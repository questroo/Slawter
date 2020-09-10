using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PostRoundSummaryManager : Singleton<PostRoundSummaryManager>
{
    public float displayTime = 20.0f;

    public GameObject postRoundDataHolder;
    public Text scoreText;
    public Text headshotText;
    public Text killsText;

    public void SetScore()
    {
        scoreText.text = RoundDataManager.Instance.CalculateScore().ToString();
    }

    public void SetHeadshots()
    {
        headshotText.text = RoundDataManager.Instance.headshots.ToString();
    }

    public void SetKills()
    {
        killsText.text = RoundDataManager.Instance.kills.ToString();
    }

    public void OpenSummary()
    {
        postRoundDataHolder.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SetScore();
        SetHeadshots();
        SetKills();
    }

    public void CloseSummary()
    {
        postRoundDataHolder.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void StartNewRound()
    {
        FindObjectOfType<SpawnerManager>().SetEnemyCount();
        CloseSummary();
    }
}
