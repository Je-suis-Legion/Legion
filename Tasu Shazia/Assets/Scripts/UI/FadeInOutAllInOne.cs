using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeInOutAllInOne : MonoBehaviour {

    private void OnEnable()
    {
        StartCoroutine(FadeImage(false));
    }

    private void OnDisable()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<TextMeshProUGUI>().color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, i);
                yield return null;
            }
            gameObject.GetComponent<TextMeshProUGUI>().color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, 0);
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, i);
                yield return null;
            }
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, 1);
        }
    }
}
