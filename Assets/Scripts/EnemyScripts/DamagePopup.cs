using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float lifeSpan;
    private Color textColor = new Color(0.0f, 0.0f, 0.0f);
    public static DamagePopup Create(Vector3 position, float damageAmount, bool isHeadshot)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.instance.damagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isHeadshot);

        return damagePopup;
    }

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }
    
    public void Setup(float damageAmount, bool isHeadshot)
    {
        if (isHeadshot) { textMesh.color = new Color(255.0f, 140.0f, 0.0f); }
        textMesh.SetText(((int)damageAmount).ToString());
        lifeSpan = 1.0f;
    }

    private void Update()
    {
        textMesh.transform.LookAt(Camera.main.transform);
        float moveYSpeed = 3.0f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0)
        {
            float disappearSpeed = 3.0f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
