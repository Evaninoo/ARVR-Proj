using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextWithFade : MonoBehaviour
{
    public Text textToShow;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(ShowAndFadeText());
    }

    IEnumerator ShowAndFadeText()
    {
        textToShow.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(FadeOutText());
        textToShow.gameObject.SetActive(false);
    }

    IEnumerator FadeOutText()
    {
        Color textColor = textToShow.color;
        float startAlpha = textColor.a;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(startAlpha, 0, t / fadeDuration);
            textColor.a = alpha;
            textToShow.color = textColor;
            yield return null;
        }

        textColor.a = 0;
        textToShow.color = textColor;
    }
}
