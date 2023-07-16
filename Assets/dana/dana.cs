using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class dana : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    public float fadeSpeed = 1.5f;
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Text text;



    // Start is called before the first frame update
    void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);

        //button = GetComponent<Button>();
       
    }

    public void page1Button()
    {
        page1.SetActive(false);

        Color buttonColor = button.image.color;
        Color textColor = text.color;

        buttonColor.a = 1.0f;
        button.image.color = buttonColor;
        textColor.a = 1.0f;
        text.color = textColor;
        page2.SetActive(true);

        StartCoroutine(FadeOut());
    }


    public void page2Button()
    {
        page2.SetActive(false);
        page3.SetActive(true);
    }

    public void page3Button()
    {
        page3.SetActive(false);
        page1.SetActive(true);
    }

    IEnumerator FadeOut()
    {
        Color buttonColor = button.image.color;
        Color textColor = text.color;
        while (buttonColor.a > 0)
        {
            Debug.Log(buttonColor.a);
            buttonColor.a -= Time.deltaTime * fadeSpeed;
            button.image.color = buttonColor;
            textColor.a -= Time.deltaTime * fadeSpeed;
            text.color = textColor;
            yield return null;
        }
    }

    //Update is called once per frame
    void Update()
    { 
    
    }
}
