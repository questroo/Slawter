using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PopupUIManager : MonoBehaviour
{
    public Text text;
    public Image textBackground;
    public float lifeSpan;
    public float fadeTime = 2.0f;

    private void Start()
    {
        textBackground.gameObject.SetActive(false);
    }


    public void DisplayEventText(string eventString)
    {
        StartCoroutine(BlipTextOnScreen(eventString));
    }

    private IEnumerator BlipTextOnScreen(string blipString)
    {
        textBackground.gameObject.SetActive(true);
        text.text = blipString;
        textBackground.CrossFadeAlpha(1.0f, fadeTime, false);
        yield return new WaitForSeconds(fadeTime);
        text.CrossFadeAlpha(0.0f, fadeTime, false);
        textBackground.CrossFadeAlpha(0.0f, fadeTime, false);
        yield return new WaitForSeconds(fadeTime);
        textBackground.CrossFadeAlpha(1.0f, 0.0f, false);
        textBackground.gameObject.SetActive(false);
    }
    public IEnumerator CountdownForRound(int timeBeforeFading)
    {
        int duration = timeBeforeFading;

        while (duration > 0)
        {
            textBackground.gameObject.SetActive(true);
            text.text = "Remaining time till next round " + duration;
            yield return new WaitForSeconds(1);
            --duration;
        }
    }
}
