using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    [SerializeField] private float visibleTime;
    [SerializeField] private float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void displayTextFadeIn()
    {
        StartCoroutine(fadeIn());
    }


    protected void displayTextFadeOut()
    {
        StartCoroutine(displayTextFadeOutRoutine());
    }

    

    IEnumerator displayTextFadeOutRoutine()
    {
        yield return new WaitForSeconds(visibleTime);

        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        while (GetComponent<TextMeshPro>().color.a > 0)
        {
            Color textColor = GetComponent<TextMeshPro>().color;
            float fadeAmount = textColor.a - (fadeSpeed * Time.deltaTime);

            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            this.GetComponent<TextMeshPro>().color = textColor;
            yield return null;
        }

        Destroy(gameObject);
    }

    IEnumerator fadeIn()
    {
        while (GetComponent<TextMeshPro>().color.a < 1)
        {
            Color textColor = GetComponent<TextMeshPro>().color;
            float fadeAmount = textColor.a + (fadeSpeed * Time.deltaTime);

            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            this.GetComponent<TextMeshPro>().color = textColor;
            yield return null;
        }
    }

    protected void displayUITextFadeIn()
    {
        StartCoroutine(fadeInUI());
    }


    protected void displayUITextFadeOut()
    {
        StartCoroutine(displayUITextFadeOutRoutine());
    }



    IEnumerator displayUITextFadeOutRoutine()
    {
        yield return new WaitForSeconds(visibleTime);

        StartCoroutine(fadeOutUI());
    }

    IEnumerator fadeOutUI()
    {
        while (GetComponent<TextMeshProUGUI>().color.a > 0)
        {
            Color textColor = GetComponent<TextMeshProUGUI>().color;
            float fadeAmount = textColor.a - (fadeSpeed * Time.deltaTime);

            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            this.GetComponent<TextMeshProUGUI>().color = textColor;
            yield return null;
        }

        Destroy(gameObject);
    }

    IEnumerator fadeInUI()
    {
        while (GetComponent<TextMeshProUGUI>().color.a < 1)
        {
            Color textColor = GetComponent<TextMeshProUGUI>().color;
            float fadeAmount = textColor.a + (fadeSpeed * Time.deltaTime);

            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            this.GetComponent<TextMeshProUGUI>().color = textColor;
            yield return null;
        }
    }
}
