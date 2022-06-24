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
    private GameObject player;
    private List<int> listLecture = new List<int>();
    private GameObject allTextEnviro;
    private AudioClip clip;
    private float textDuration;
    private Color color;
    private bool isPlaying = false;

    void Start()
    {
        dialogues = JsonUtility.FromJson<Dialogues>(json.text);
        player = GameObject.Find("Player");
        allTextEnviro = GameObject.Find("AllTextEnvironmentaux");
        //SoustitreVoice(0,gameObject);
        //Cinematique d'intro
        ajoutList(0);
        StartCoroutine(SoustitreVoice(0, player));
    }

    public void ajoutList(int id)
    {
        Debug.Log("Ajout");
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
        Debug.Log("Remove");
        if (listLecture.Count != 0)
        {
            int idTemp = listLecture[0];
            //Tester son fonctionnement
            //StopAllCoroutines();
            //
            listLecture.Remove(listLecture[0]);
        
            if (dialogues.dialogues[idTemp].continuer)
            {
                removeList();
            }
        }
    }

    public IEnumerator SoustitreVoice(int id, GameObject objetSonore)
    {
        Debug.Log("Soutitres");
        if (!isPlaying)
        {
            Debug.Log("PLaySoustitre");
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

            switch (id)
            {
                case 34 :
                    allTextEnviro.transform.GetChild(21).gameObject.SetActive(true);
                    break;
                case 39 :
                    allTextEnviro.transform.GetChild(26).gameObject.SetActive(true);
                    break;
                case 54 :
                    allTextEnviro.transform.GetChild(41).gameObject.SetActive(true);
                    break;
                case 63 :
                    allTextEnviro.transform.GetChild(50).gameObject.SetActive(true);
                    break;
                case 65 :
                    allTextEnviro.transform.GetChild(52).gameObject.SetActive(true);
                    break;
                case 66 :
                    allTextEnviro.transform.GetChild(53).gameObject.SetActive(true);
                    break;
                case 67 :
                    allTextEnviro.transform.GetChild(54).gameObject.SetActive(true);
                    break;
                case 75 :
                    allTextEnviro.transform.GetChild(62).gameObject.SetActive(true);
                    allTextEnviro.transform.GetChild(63).gameObject.SetActive(true);
                    break;
                case 82 :
                    allTextEnviro.transform.GetChild(76).gameObject.SetActive(true);
                    break;
                case 92 :
                    allTextEnviro.transform.GetChild(86).gameObject.SetActive(true);
                    break;
                case 94 :
                    allTextEnviro.transform.GetChild(88).gameObject.SetActive(true);
                    break;
                case 101 :
                    allTextEnviro.transform.GetChild(95).gameObject.SetActive(true);
                    break;
                case 103 :
                    allTextEnviro.transform.GetChild(97).gameObject.SetActive(true);
                    break;
                case 104 :
                    allTextEnviro.transform.GetChild(98).gameObject.SetActive(true);
                    break;
                case 106 :
                    allTextEnviro.transform.GetChild(100).gameObject.SetActive(true);
                    break;
                case 110 :
                    allTextEnviro.transform.GetChild(104).gameObject.SetActive(true);
                    break;
                case 111 :
                    allTextEnviro.transform.GetChild(105).gameObject.SetActive(true);
                    break;
                case 120 :
                    allTextEnviro.transform.GetChild(114).gameObject.SetActive(true);
                    break;
                case 122 :
                    allTextEnviro.transform.GetChild(116).gameObject.SetActive(true);
                    break;
            }

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
