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

    void Start()
    {
        dialogues = JsonUtility.FromJson<Dialogues>(json.text);
        gameObject.GetComponent<TextMeshPro>().color = tradColor(dialogues.dialogues[idText].color);
        gameObject.GetComponent<TextMeshPro>().text =
            dialogues.dialogues[idText].name + " : " + dialogues.dialogues[idText].dialogue;
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
}
