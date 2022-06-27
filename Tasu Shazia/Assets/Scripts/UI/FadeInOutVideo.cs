using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class FadeInOutVideo : MonoBehaviour
{
    private bool debut = true;
    private void OnEnable()
    {
        if (!debut)
        {
            StartCoroutine(FadeImage(false));
        }
    }

    private void OnDisable()
    {
        StartCoroutine(FadeImage(true));
        debut = false;
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        yield return new WaitForSeconds(1);
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<RawImage>().color = new Color(gameObject.GetComponent<RawImage>().color.r, gameObject.GetComponent<RawImage>().color.g, gameObject.GetComponent<RawImage>().color.b, i);
                yield return null;
            }
            gameObject.GetComponent<RawImage>().color = new Color(gameObject.GetComponent<RawImage>().color.r, gameObject.GetComponent<RawImage>().color.g, gameObject.GetComponent<RawImage>().color.b, 0);
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<RawImage>().color = new Color(gameObject.GetComponent<RawImage>().color.r, gameObject.GetComponent<RawImage>().color.g, gameObject.GetComponent<RawImage>().color.b, i);
                yield return null;
            }
            gameObject.GetComponent<RawImage>().color = new Color(gameObject.GetComponent<RawImage>().color.r, gameObject.GetComponent<RawImage>().color.g, gameObject.GetComponent<RawImage>().color.b, 1);
        }
    }
}
