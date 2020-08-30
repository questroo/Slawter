using UnityEngine;
using TMPro;
using System.Collections;

public class PopupUIManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public float lifeSpan;

    private void Start()
    {
        textBox.alpha = 0.0f;
    }

    public void DisplayEventText(string eventString)
    {
        StartCoroutine(BlipEventString(eventString));
    }

    private IEnumerator BlipEventString(string eventString)
    {
        if (eventString is null)
        {
            throw new System.ArgumentNullException(nameof(eventString));
        }

        float t = 0;
        Color32 startColor = new Color32(255, 255, 255, 0);
        Color32 endColor = new Color32(255, 255, 255, 255);

        textBox.color = startColor;
        textBox.text = eventString;

        while (t < 1)
        {
            textBox.color = Color32.Lerp(startColor, endColor, t);
            t += Time.deltaTime / lifeSpan;
            yield return null;
        }
        t = 0;
        while(t < 1)
        {
            textBox.color = Color32.Lerp(endColor, startColor, t);
            t += Time.deltaTime / lifeSpan;
            yield return null;
        }
        textBox.alpha = 0;
    }
}
