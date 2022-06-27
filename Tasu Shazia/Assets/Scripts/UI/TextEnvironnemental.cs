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
        /*dialogues = JsonUtility.FromJson<Dialogues>(json.text);
        gameObject.GetComponent<TextMeshPro>().color = tradColor(dialogues.dialogues[idText].color);
        gameObject.GetComponent<TextMeshPro>().text = dialogues.dialogues[idText].dialogue;*/
    }

    private void OnEnable()
    {
        /*StartCoroutine(Fade(false));
        transform.position = GameObject.Find("Player").transform.GetChild(1).GetChild(0).position + GameObject.Find("Player").transform.GetChild(1).GetChild(0).forward * 10;
        transform.rotation = GameObject.Find("Player").transform.GetChild(1).GetChild(0).rotation;*/
    }

    public void Disable()
    {
        /*StartCoroutine(Fade(true));
        gameObject.SetActive(false);*/
    }

    private void FixedUpdate()
    {
        //transform.LookAt(2 * transform.position - GameObject.Find("Player").transform.position);
    }

    private Color tradColor(string color)
    {
        Color couleur = Color.clear;

        switch (color)
        {
            case "noir" : couleur = Color.clear;
                break;
            case "bleu" :
                couleur = Color.clear;
                break;
            case "cyan" : couleur = Color.clear;
                break;
            case "gris" : couleur = Color.clear;
                break;
            case "vert" : couleur = Color.clear;
                break;
            case "rose" : couleur = Color.clear;
                break;
            case "rouge" : couleur = Color.clear;
                break;
            case "blanc" : couleur = Color.clear;
                break;
            case "jaune" : couleur = Color.clear;
                break;
            case "violet" : couleur = Color.clear;
                break;
            case "orange" : couleur = Color.clear;
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
                gameObject.GetComponent<TextMeshPro>().color = new Color(gameObject.GetComponent<TextMeshPro>().color.r, gameObject.GetComponent<TextMeshPro>().color.g, gameObject.GetComponent<TextMeshPro>().color.b, i);
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
                gameObject.GetComponent<TextMeshPro>().color = new Color(gameObject.GetComponent<TextMeshPro>().color.r, gameObject.GetComponent<TextMeshPro>().color.g, gameObject.GetComponent<TextMeshPro>().color.b, i);
                yield return null;
            }
        }
    }
}
