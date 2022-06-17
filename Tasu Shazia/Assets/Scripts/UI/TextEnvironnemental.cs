using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEnvironnemental : MonoBehaviour
{
    public static Dialogues dialogues;
    public TextAsset json;
    public int idText;
    
    private Color color;

    private void Awake()
    {
        dialogues = JsonUtility.FromJson<Dialogues>(json.text);
        gameObject.GetComponent<TextMeshProUGUI>().color = tradColor(dialogues.dialogues[idText].color);
        gameObject.GetComponent<TextMeshProUGUI>().text = dialogues.dialogues[idText].dialogue;
    }

    private void OnEnable()
    {
        StartCoroutine(Fade(false));
    }

    public void Disable()
    {
        StartCoroutine(Fade(true));
        gameObject.SetActive(false);
    }

    private Color tradColor(string color)
    {
        Color couleur = Color.black;

        switch (color)
        {
            case "noir" : couleur = Color.black;
                break;
            case "bleu" : couleur = Color.blue;
                break;
            case "cyan" : couleur = Color.cyan;
                break;
            case "gris" : couleur = Color.gray;
                break;
            case "vert" : couleur = Color.green;
                break;
            case "rose" : couleur = Color.magenta;
                break;
            case "rouge" : couleur = Color.red;
                break;
            case "blanc" : couleur = Color.white;
                break;
            case "jaune" : couleur = Color.yellow;
                break;
            case "violet" : couleur = new Color(148,0,211);
                break;
            case "orange" : couleur = new Color(255, 69, 0);
                break;
        }

        return couleur;
    }
    
    IEnumerator Fade(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<TextMeshProUGUI>().color = new Color(gameObject.GetComponent<TextMeshProUGUI>().color.r, gameObject.GetComponent<TextMeshProUGUI>().color.g, gameObject.GetComponent<TextMeshProUGUI>().color.b, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<TextMeshProUGUI>().color = new Color(gameObject.GetComponent<TextMeshProUGUI>().color.r, gameObject.GetComponent<TextMeshProUGUI>().color.g, gameObject.GetComponent<TextMeshProUGUI>().color.b, i);
                yield return null;
            }
        }
    }
}
