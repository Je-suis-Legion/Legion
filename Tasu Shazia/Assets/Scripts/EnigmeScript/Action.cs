using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Action : MonoBehaviour
{
    private GameObject player;
    private GameObject allInteractable;
    private GameObject canvasPlayer;
    private GameObject sousTitres;
    private GameObject allTextEnviro;

    private List<GameObject> listGonds = new List<GameObject>();
    private List<GameObject> barreAndKey = new List<GameObject>();
    private bool odeurPorteFirts = true;
    private bool hasClef = false;
    
    //A Ameliorer avec un parent commun et des get child
    public List<GameObject> listOdeurRouille = new List<GameObject>();
    public GameObject odeurBarre;
    public GameObject odeurClef;
    
    private List<GameObject> allSymbolesVue = new List<GameObject>();
    private bool vuePorteFirst = true;
    private PositionCadenas positionCadenas;
    private bool codeInAnim = false;
    private GameObject cadenas;
    private int code = 1;
    private int codeMax = 6;
    private bool goodCode = false;
    
    public bool isInteractible = true;
    
    private List<GameObject> charettes = new List<GameObject>();
    
    private void Awake()
    {
        player = GameObject.Find("Player");
        allInteractable = GameObject.Find("allInteractable");
        canvasPlayer = GameObject.Find("CanvasPlayer");
        sousTitres = canvasPlayer.transform.GetChild(0).GetChild(1).gameObject;
        allTextEnviro = canvasPlayer.transform.GetChild(0).GetChild(3).gameObject;
        
        foreach (Transform i in allInteractable.transform.GetChild(0))
        {
            listGonds.Add(i.gameObject);
        }
        
        barreAndKey.Add(allInteractable.transform.GetChild(3).gameObject);
        barreAndKey.Add(allInteractable.transform.GetChild(4).gameObject);

        foreach (Transform i in GameObject.Find("allSymbolesVue").transform)
        {
            allSymbolesVue.Add(i.gameObject);
        }

        switch (gameObject.name)
        {
            case "Code1" :
                positionCadenas = PositionCadenas.gauche;
                break;
            case "Code2" :
                positionCadenas = PositionCadenas.centre;
                break;
            case "Code3" :
                positionCadenas = PositionCadenas.droite;
                break;
        }

        cadenas = allInteractable.transform.GetChild(7).gameObject;

        foreach (Transform i in allInteractable.transform.GetChild(9))
        {
            charettes.Add(i.gameObject);
        }
    }

    //Penser a ajouter les triggers
    public void ActionEffectuer()
    {
        switch (gameObject.name)
        {
            case "Gond" :
                //Son du brisage des gonds
                GameObject.Find("PorteCellule").GetComponent<Action>().listGonds.Remove(gameObject);
                Destroy(gameObject);
                break;
            case "PorteCellule" :
                if (listGonds.Count == 0)
                {
                    gameObject.GetComponent<Animator>().SetBool("Fall",true);
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(32);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(32, player));
                    allTextEnviro.transform.GetChild(19).gameObject.SetActive(true);
                }
                break;
            case "PorteOdeur" :
                if (odeurPorteFirts)
                {
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(47);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(47, player));
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
                        sousTitres.GetComponent<SoustitresVoices>().ajoutList(59);
                        StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(59, player));
                        allTextEnviro.transform.GetChild(46).gameObject.SetActive(true);
                        hasClef = false;
                        player.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
                        //activer l'animation du candenas et de la porte
                    }
                    else
                    {
                        int temp = Random.Range(57, 59);
                        sousTitres.GetComponent<SoustitresVoices>().ajoutList(temp);
                        StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(temp, player));
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
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(51);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(51, player));
                allTextEnviro.transform.GetChild(38).gameObject.SetActive(true);
                odeurBarre.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Clef" :
                player.GetComponent<PlayerMovement>().distanceInteractions = 3;
                player.transform.GetChild(1).GetChild(6).gameObject.SetActive(false);
                player.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(56);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(56, player));
                allTextEnviro.transform.GetChild(43).gameObject.SetActive(true);
                odeurClef.SetActive(false);
                hasClef = true;
                gameObject.SetActive(false);
                break;
            case "Marmitte" :
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(62);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(62, player));
                allTextEnviro.transform.GetChild(49).gameObject.SetActive(true);
                break;
            case "PorteVue" :
                if (vuePorteFirst)
                {
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(87);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(87, player));
                    allTextEnviro.transform.GetChild(81).gameObject.SetActive(true);
                    player.GetComponent<PlayerEffetVue>().enabled = true;
                    foreach (var i in allSymbolesVue)
                    {
                        i.SetActive(true);
                    }
                }
                else
                {
                    if (!goodCode)
                    {
                        sousTitres.GetComponent<SoustitresVoices>().ajoutList(98);
                        StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(98, player));
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
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(161);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(161, player));
                allTextEnviro.transform.GetChild(134).gameObject.SetActive(true);
                gameObject.layer = LayerMask.GetMask("Default");
                StartCoroutine(Reactivate(10));
                break;
            case "BonneCharette" :
                player.GetComponent<Look>().enabled = false;
                player.GetComponent<PlayerMovement>().canMove = false;
                player.GetComponent<PlayerMovement>().canInteract = false;
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(156);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(156, player));
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
