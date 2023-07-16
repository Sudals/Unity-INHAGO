using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    public bool fadeInOnStart = true;
    public bool fadeOutOnExit = true;

    private CanvasGroup canvasGroup;

    private Button button;


    void Start()
    {
        button = GetComponent<Button>();
        if (fadeInOnStart)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        Color buttonColor = button.image.color;
        while (buttonColor.a > 0)
        {
            Debug.Log(buttonColor.a);
            buttonColor.a -= Time.deltaTime * fadeSpeed;
            button.image.color = buttonColor;
            yield return null;
        }
    }
}
