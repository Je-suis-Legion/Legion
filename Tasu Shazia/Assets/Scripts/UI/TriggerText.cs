using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TriggerText : MonoBehaviour
{
    private GameObject player;
    private GameObject zoneDialogue;
    private GameObject allTextEnviro;

    private void Awake()
    {
        player = GameObject.Find("Player");
        zoneDialogue = GameObject.Find("CanvasPlayer").transform.GetChild(0).GetChild(2).gameObject;
        allTextEnviro = GameObject.Find("AllTextEnvironmentaux");
    }

    private void OnEnable()
    {
        if (gameObject.name == "Id104 (Trigger chemin random)" || gameObject.name == "Id106 (Trigger chemin random 2)" || gameObject.name == "Id110 (Trigger chemin random 3)")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(Reactivate(120));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.name)
        {
            case "Id34 (Explo sortie cellule)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(34);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(34, player));
                //allTextEnviro.transform.GetChild(21).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id39 (Marmitte)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(39);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(39, player));
                //allTextEnviro.transform.GetChild(26).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id54 (Première vue clef chien)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(54);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(54, player));
                //allTextEnviro.transform.GetChild(41).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id63 (Ruines à gauche du spawn)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(63);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(63, player));
                //allTextEnviro.transform.GetChild(50).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id65 (Impasse en haut de la map)" :
                int temp = Random.Range(65, 67);
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(temp);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(temp, player));
                /*switch (temp)
                {
                    case 65 :
                        allTextEnviro.transform.GetChild(52).gameObject.SetActive(true);
                        break;
                    case 66 :
                        allTextEnviro.transform.GetChild(53).gameObject.SetActive(true);
                        break;
                }*/
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Reactivate(120));
                break;
            case "Id67 (Statue)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(67);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(67, player));
                //allTextEnviro.transform.GetChild(54).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id75 (Premier passage chemin nord ou sud)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(75);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(75, player));
                //allTextEnviro.transform.GetChild(62).gameObject.SetActive(true);
                //allTextEnviro.transform.GetChild(63).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id82 (Premier passage vers la porte zone 2)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(82);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(82, player));
                //allTextEnviro.transform.GetChild(76).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id92 (Ruines nord post statue)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(92);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(92, player));
                //allTextEnviro.transform.GetChild(86).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id94 (Ruines sud post statue)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(94);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(94, player));
                //allTextEnviro.transform.GetChild(88).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id101 (Trigger traces de pas)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(101);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(101, player));
                //allTextEnviro.transform.GetChild(95).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id103 (Trigger traces de pas 2)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(103);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(103, player));
                //allTextEnviro.transform.GetChild(97).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id104 (Trigger chemin random)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(104);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(104, player));
                //allTextEnviro.transform.GetChild(98).gameObject.SetActive(true);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Reactivate(120));
                break;
            case "Id106 (Trigger chemin random 2)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(106);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(106, player));
                //allTextEnviro.transform.GetChild(100).gameObject.SetActive(true);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Reactivate(120));
                break;
            case "Id110 (Trigger chemin random 3)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(110);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(110, player));
                //allTextEnviro.transform.GetChild(104).gameObject.SetActive(true);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Reactivate(120));
                break;
            case "Id111 (Trigger du clocher)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(111);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(111, player));
                //allTextEnviro.transform.GetChild(105).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id120 (Passage entre maison NO et NE)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(120);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(120, player));
                //allTextEnviro.transform.GetChild(114).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Id122 (Premier passag centre village)" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(122);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(122, player));
                //allTextEnviro.transform.GetChild(116).gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
        }
    }

    private IEnumerator Reactivate(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<BoxCollider>().enabled = true;
        yield return null;
    }
}
