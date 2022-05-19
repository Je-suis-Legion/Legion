using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoustitresVoices : MonoBehaviour
{
    public static Dialogues dialogues;
    public TextAsset json;

    void Start()
    {
        dialogues = JsonUtility.FromJson<Dialogues>(json.text);
        SoustitreVoice(0,gameObject);
    }

    public void SoustitreVoice(int id, GameObject objetSonore)
    {
        StartCoroutine(DefilementText(id, 0.2f));
        gameObject.GetComponent<TextMeshProUGUI>().color = tradColor(dialogues.dialogues[id].color);
        Debug.Log(dialogues.dialogues[id].path);
        Debug.Log(Resources.Load(dialogues.dialogues[id].path));
        objetSonore.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load(dialogues.dialogues[id].path);
        objetSonore.GetComponent<AudioSource>().Play();
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
        }

        return couleur;
    }

    private IEnumerator DefilementText(int id, float speed)
    {
        for (int i = 0; i < dialogues.dialogues[id].name.Length; i++)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = dialogues.dialogues[id].name.Remove(i);
            yield return new WaitForSeconds(speed);
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = dialogues.dialogues[id].name;
        yield return new WaitForSeconds(speed);
        gameObject.GetComponent<TextMeshProUGUI>().text = dialogues.dialogues[id].name + " : ";
        yield return new WaitForSeconds(speed);
        
        for (int i = 0; i < dialogues.dialogues[id].dialogue.Length; i++)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = dialogues.dialogues[id].name + " : " + dialogues.dialogues[id].dialogue.Remove(i);
            yield return new WaitForSeconds(speed);
        }
        gameObject.GetComponent<TextMeshProUGUI>().text =
            dialogues.dialogues[id].name + " : " + dialogues.dialogues[id].dialogue;
        
        yield return null;
    }
}
