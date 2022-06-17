using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Action : MonoBehaviour
{
    private GameObject player;
    public GameObject zoneDialogue;
    public GameObject allTextEnviro;

    public List<GameObject> listGonds;

    public List<GameObject> listOdeurRouille;
    public List<GameObject> barreAndKey;
    private bool odeurPorteFirts = true;
    public GameObject odeurBarre;
    public GameObject odeurClef;
    private bool hasClef = false;

    public List<GameObject> listCodes;
    private bool vuePorteFirst = true;
    public PositionCadenas positionCadenas;
    public bool isInteractible = true;
    private bool codeInAnim = false;
    public GameObject cadenas;
    private int code = 1;
    private int codeMax = 6;
    public bool goodCode = false;

    public List<GameObject> charettes;
    
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    //Penser a ajouter les triggers
    public void ActionEffectuer()
    {
        switch (gameObject.name)
        {
            case "Gond" :
                //animation de chute gonds soit en anim soit en forces
                break;
            case "PorteCellule" :
                if (listGonds.Count == 0)
                {
                    //anim de la chute de la porte soit en anim soit en forces
                    zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(32);
                    StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(32, player));
                    allTextEnviro.transform.GetChild(19).gameObject.SetActive(true);
                }
                break;
            case "PorteOdeur" :
                if (odeurPorteFirts)
                {
                    zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(47);
                    StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(47, player));
                    allTextEnviro.transform.GetChild(34).gameObject.SetActive(true);
                    foreach (var i in listOdeurRouille)
                    {
                        i.SetActive(true);
                    }
                    foreach (var i in barreAndKey)
                    {
                        i.layer = LayerMask.GetMask("Interactable");
                    }
                    odeurPorteFirts = false;
                }
                else
                {
                    if (hasClef)
                    {
                        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(59);
                        StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(59, player));
                        allTextEnviro.transform.GetChild(46).gameObject.SetActive(true);
                        hasClef = false;
                        player.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
                        //activer l'animation du candenas et de la porte
                    }
                    else
                    {
                        int temp = Random.Range(57, 59);
                        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(temp);
                        StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(temp, player));
                        switch (temp)
                        {
                            case 57 :
                                allTextEnviro.transform.GetChild(44).gameObject.SetActive(true);
                                break;
                            case 58 :
                                allTextEnviro.transform.GetChild(45).gameObject.SetActive(true);
                                break;
                        }
                    }
                }
                break;
            case "BarreDeFer" :
                player.GetComponent<PlayerMovement>().distanceInteractions = 10;
                player.transform.GetChild(1).GetChild(6).gameObject.SetActive(true);
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(51);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(51, player));
                allTextEnviro.transform.GetChild(38).gameObject.SetActive(true);
                odeurBarre.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Clef" :
                player.GetComponent<PlayerMovement>().distanceInteractions = 3;
                player.transform.GetChild(1).GetChild(6).gameObject.SetActive(false);
                player.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(56);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(56, player));
                allTextEnviro.transform.GetChild(43).gameObject.SetActive(true);
                odeurClef.SetActive(false);
                hasClef = true;
                gameObject.SetActive(false);
                break;
            case "Marmitte" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(62);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(62, player));
                allTextEnviro.transform.GetChild(49).gameObject.SetActive(true);
                break;
            case "PorteVue" :
                if (vuePorteFirst)
                {
                    zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(87);
                    StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(87, player));
                    allTextEnviro.transform.GetChild(81).gameObject.SetActive(true);
                    player.GetComponent<PlayerEffetVue>().enabled = true;
                    foreach (var i in listCodes)
                    {
                        i.SetActive(true);
                    }
                }
                else
                {
                    if (!goodCode)
                    {
                        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(98);
                        StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(98, player));
                        allTextEnviro.transform.GetChild(92).gameObject.SetActive(true);
                        //activer l'animation du candenas et de la porte
                    }
                }
                break;
            case "Code1" :
                if (isInteractible && !codeInAnim)
                {
                    if (code == codeMax)
                    {
                        code = 1;
                    }
                    else
                    {
                        code++;
                    }

                    switch (code)
                    {
                        case 1 :
                            StartCoroutine(RotationCadenas(0, 60));
                            break;
                        case 2 :
                            StartCoroutine(RotationCadenas(60, 120));
                            break;
                        case 3 :
                            StartCoroutine(RotationCadenas(120, 180));
                            break;
                        case 4 :
                            StartCoroutine(RotationCadenas(180, 240));
                            break;
                        case 5 :
                            StartCoroutine(RotationCadenas(240, 300));
                            break;
                        case 6 :
                            StartCoroutine(RotationCadenas(300, 360));
                            break;
                    }

                    switch (positionCadenas)
                    {
                        case PositionCadenas.gauche:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[0] = code;
                            break;
                        case PositionCadenas.centre:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[1] = code;
                            break;
                        case PositionCadenas.droite:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[2] = code;
                            break;
                    }
            
                    cadenas.GetComponent<CompteurBoutons>().CheckList();
                    //animation de rotation de 60 degres vers le haut (sur l'axe z normalement)
                }
                break;
            case "Code2" :
                if (isInteractible && !codeInAnim)
                {
                    if (code == codeMax)
                    {
                        code = 1;
                    }
                    else
                    {
                        code++;
                    }
                    
                    switch (code)
                    {
                        case 1 :
                            StartCoroutine(RotationCadenas(0, 60));
                            break;
                        case 2 :
                            StartCoroutine(RotationCadenas(60, 120));
                            break;
                        case 3 :
                            StartCoroutine(RotationCadenas(120, 180));
                            break;
                        case 4 :
                            StartCoroutine(RotationCadenas(180, 240));
                            break;
                        case 5 :
                            StartCoroutine(RotationCadenas(240, 300));
                            break;
                        case 6 :
                            StartCoroutine(RotationCadenas(300, 360));
                            break;
                    }

                    switch (positionCadenas)
                    {
                        case PositionCadenas.gauche:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[0] = code;
                            break;
                        case PositionCadenas.centre:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[1] = code;
                            break;
                        case PositionCadenas.droite:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[2] = code;
                            break;
                    }
            
                    cadenas.GetComponent<CompteurBoutons>().CheckList();
                    //animation de rotation de 60 degres vers le haut (sur l'axe z normalement)
                }
                break;
            case "Code3" :
                if (isInteractible && !codeInAnim)
                {
                    if (code == codeMax)
                    {
                        code = 1;
                    }
                    else
                    {
                        code++;
                    }
                    
                    switch (code)
                    {
                        case 1 :
                            StartCoroutine(RotationCadenas(0, 60));
                            break;
                        case 2 :
                            StartCoroutine(RotationCadenas(60, 120));
                            break;
                        case 3 :
                            StartCoroutine(RotationCadenas(120, 180));
                            break;
                        case 4 :
                            StartCoroutine(RotationCadenas(180, 240));
                            break;
                        case 5 :
                            StartCoroutine(RotationCadenas(240, 300));
                            break;
                        case 6 :
                            StartCoroutine(RotationCadenas(300, 360));
                            break;
                    }

                    switch (positionCadenas)
                    {
                        case PositionCadenas.gauche:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[0] = code;
                            break;
                        case PositionCadenas.centre:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[1] = code;
                            break;
                        case PositionCadenas.droite:
                            cadenas.GetComponent<CompteurBoutons>().codeCadenas[2] = code;
                            break;
                    }
            
                    cadenas.GetComponent<CompteurBoutons>().CheckList();
                    //animation de rotation de 60 degres vers le haut (sur l'axe z normalement)
                }
                break;
            case "MurUtile" :
                foreach (var i in charettes)
                {
                    i.layer = LayerMask.GetMask("Interactable");
                }
                break;
            case "MauvaiseCharette" :
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(161);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(161, player));
                allTextEnviro.transform.GetChild(134).gameObject.SetActive(true);
                gameObject.layer = LayerMask.GetMask("Default");
                StartCoroutine(Reactivate(10));
                break;
            case "BonneCharette" :
                player.GetComponent<Look>().enabled = false;
                player.GetComponent<PlayerMovement>().canMove = false;
                player.GetComponent<PlayerMovement>().canInteract = false;
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(156);
                StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(156, player));
                allTextEnviro.transform.GetChild(129).gameObject.SetActive(true);
                break;
        }
    }
    
    private IEnumerator Reactivate(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.layer = LayerMask.GetMask("Interactable");
        yield return null;
    }
    
    private IEnumerator RotationCadenas(float rotationActuelle, float objectif)
    {
        codeInAnim = true;
        float timeElapsed = 0;
        while (timeElapsed < 1) 
        {
            transform.rotation = Quaternion.Euler(Mathf.Lerp(rotationActuelle,objectif, timeElapsed / 1), transform.rotation.y, 90);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.Euler(objectif, transform.rotation.y, 90);
        codeInAnim = false;
    }
}

public enum PositionCadenas
{
    gauche,
    centre,
    droite
}
