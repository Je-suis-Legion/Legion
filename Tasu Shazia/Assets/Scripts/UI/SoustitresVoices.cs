using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SoustitresVoices : MonoBehaviour
{
    public static Dialogues dialogues;
    public TextAsset json;
    
    [SerializeField]
    private List<int> listLecture;
    private AudioClip clip;
    private float textDuration;
    private Color color;
    private bool isPlaying = false;

    void Start()
    {
        dialogues = JsonUtility.FromJson<Dialogues>(json.text);
        //SoustitreVoice(0,gameObject);
    }

    public void ajoutList(int id)
    {
        if (!listLecture.Contains(dialogues.dialogues[id].id))
        {
            int idTemp = id;
            listLecture.Add(dialogues.dialogues[id].id);

            if (dialogues.dialogues[idTemp].continuer)
            {
                ajoutList(id + 1);
            }
        }
    }

    public void removeList()
    {
        int idTemp = listLecture[0];
        listLecture.Remove(listLecture[0]);
        
        if (dialogues.dialogues[idTemp].continuer)
        {
            removeList();
        }
    }

    public IEnumerator SoustitreVoice(int id, GameObject objetSonore)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            clip = (AudioClip) Resources.Load(dialogues.dialogues[listLecture[0]].path);
            textDuration = clip.length / dialogues.dialogues[listLecture[0]].dialogue.Length;
            
            if (dialogues.dialogues[listLecture[0]].path != "null")
            {
                objetSonore.GetComponent<AudioSource>().clip = clip;
                objetSonore.GetComponent<AudioSource>().Play();
            }
            gameObject.GetComponent<TextMeshProUGUI>().color = tradColor(dialogues.dialogues[listLecture[0]].color);
            StartCoroutine(DefilementText(listLecture[0], textDuration, objetSonore));

            yield return null;
        }
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

    private IEnumerator DefilementText(int id, float speed, GameObject objetSonore)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = dialogues.dialogues[id].name + " : ";

        for (int i = 0; i < dialogues.dialogues[id].dialogue.Length; i++)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = dialogues.dialogues[id].name + " : " + dialogues.dialogues[id].dialogue.Remove(i);
            yield return new WaitForSeconds(speed);
        }
        gameObject.GetComponent<TextMeshProUGUI>().text =
            dialogues.dialogues[id].name + " : " + dialogues.dialogues[id].dialogue;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<TextMeshProUGUI>().text = "";
        isPlaying = false;
        GameObject.Find("Player").GetComponent<TextFinish>().Action(dialogues.dialogues[id].id);
        listLecture.Remove(listLecture[0]);
        if (listLecture.Any())
        {
            StartCoroutine(SoustitreVoice(listLecture[0], objetSonore));
        }
        
        yield return null;
    }
}
