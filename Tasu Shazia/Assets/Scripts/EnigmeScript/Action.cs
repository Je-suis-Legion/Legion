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
    private GameObject allTriggerText;

    private List<GameObject> listGonds = new List<GameObject>();
    private List<GameObject> barreAndKey = new List<GameObject>();
    private bool odeurPorteFirts = true;
    private bool hasClef = false;
    
    //A Ameliorer avec un parent commun et des get child
    public List<GameObject> listOdeurRouille = new List<GameObject>();
    public GameObject odeurBarre;
    public GameObject odeurClef;
    public GameObject odeurMarmitte;
    
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
        allTextEnviro = GameObject.Find("AllTextEnvironmentaux");
        sousTitres = canvasPlayer.transform.GetChild(0).GetChild(2).gameObject;
        allTriggerText = GameObject.Find("AllTextTrigger");

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

        cadenas = allInteractable.transform.GetChild(6).gameObject;

        foreach (Transform i in allInteractable.transform.GetChild(8))
        {
            charettes.Add(i.gameObject);
        }
        
        allInteractable.transform.GetChild(2).gameObject.GetComponent<Animator>().speed = 0;
    }
    
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
                    
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).GetChild(1).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).GetChild(2).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(1).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(2).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(2).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(3).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(3).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(3).GetChild(1).gameObject.GetComponent<FadeInOutText>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(4).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(4).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(4).GetChild(1).gameObject.GetComponent<FadeInOutText>().enabled = false;
                    GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(5).gameObject.GetComponent<FadeInOut>().enabled = false;
                    
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(32);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(32, player));
                    allTextEnviro.transform.GetChild(19).gameObject.SetActive(true);
                    gameObject.GetComponent<Outline>().enabled = false;
                    gameObject.layer = LayerMask.NameToLayer("Default");
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
                        i.layer = LayerMask.NameToLayer("Interactable");
                        i.GetComponent<Outline>().enabled = true;
                    }
                    allInteractable.transform.GetChild(5).GetChild(1).gameObject.layer = LayerMask.NameToLayer("Interactable");
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
                        transform.parent.parent.gameObject.GetComponent<Animator>().speed = 1;
                        gameObject.layer = LayerMask.NameToLayer("Default");
                        gameObject.GetComponent<Outline>().enabled = false;
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
                transform.parent.GetChild(2).GetChild(2).GetChild(0).GetComponent<Action>().hasClef = true;
                gameObject.SetActive(false);
                break;
            case "Marmitte" :
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(62);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(62, player));
                allTextEnviro.transform.GetChild(49).gameObject.SetActive(true);
                gameObject.layer = LayerMask.NameToLayer("Default");
                odeurMarmitte.SetActive(false);
                gameObject.GetComponent<Outline>().enabled = false;
                break;
            case "PorteVue" :
                Debug.Log(vuePorteFirst);
                if (vuePorteFirst)
                {
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(87);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(87, player));
                    allTextEnviro.transform.GetChild(81).gameObject.SetActive(true);
                    foreach (var i in allSymbolesVue)
                    {
                        i.SetActive(true);
                    }

                    transform.parent.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(1).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(2).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    
                    allTriggerText.transform.GetChild(8).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(9).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(10).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(11).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(12).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(13).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(14).gameObject.SetActive(true);
                }
                else
                {
                    if (!goodCode)
                    {
                        sousTitres.GetComponent<SoustitresVoices>().ajoutList(98);
                        StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(98, player));
                        allTextEnviro.transform.GetChild(92).gameObject.SetActive(true);
                    }
                }
                break;
            case "Code1" :
                Debug.Log(vuePorteFirst);
                if (vuePorteFirst)
                {
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(87);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(87, player));
                    allTextEnviro.transform.GetChild(81).gameObject.SetActive(true);
                    foreach (var i in allSymbolesVue)
                    {
                        i.SetActive(true);
                    }

                    transform.parent.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(1).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(2).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    
                    allTriggerText.transform.GetChild(8).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(9).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(10).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(11).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(12).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(13).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(14).gameObject.SetActive(true);
                }
                else
                {
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
                    }
                }
                break;
            case "Code2" :
                Debug.Log(vuePorteFirst);
                if (vuePorteFirst)
                {
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(87);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(87, player));
                    allTextEnviro.transform.GetChild(81).gameObject.SetActive(true);
                    foreach (var i in allSymbolesVue)
                    {
                        i.SetActive(true);
                    }

                    transform.parent.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(1).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(2).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    
                    allTriggerText.transform.GetChild(8).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(9).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(10).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(11).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(12).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(13).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(14).gameObject.SetActive(true);
                }
                else
                {
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
                    }
                }
                break;
            case "Code3" :
                Debug.Log(vuePorteFirst);
                if (vuePorteFirst)
                {
                    sousTitres.GetComponent<SoustitresVoices>().ajoutList(87);
                    StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(87, player));
                    allTextEnviro.transform.GetChild(81).gameObject.SetActive(true);
                    foreach (var i in allSymbolesVue)
                    {
                        i.SetActive(true);
                    }

                    transform.parent.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(0).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(1).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    transform.parent.parent.GetChild(1).GetChild(2).gameObject.GetComponent<Action>().vuePorteFirst =
                        false;
                    
                    allTriggerText.transform.GetChild(8).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(9).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(10).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(11).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(12).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(13).gameObject.SetActive(true);
                    allTriggerText.transform.GetChild(14).gameObject.SetActive(true);
                }
                else
                {
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
                            //-18.82f
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
                    }
                }
                break;
            case "MurUtile" :
                foreach (var i in charettes)
                {
                    i.layer = LayerMask.NameToLayer("Interactable");
                    i.GetComponent<Outline>().enabled = true;
                }
                break;
            case "MurInutile" :
                int temp2 = Random.Range(147, 152);
                while (temp2 == 148 || temp2 == 151)
                {
                    temp2 = Random.Range(147, 152);
                }
                /*sousTitres.GetComponent<SoustitresVoices>().ajoutList(temp2);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(temp2, player));*/
                break;
            case "MauvaiseCharette" :
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(161);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(161, player));
                allTextEnviro.transform.GetChild(134).gameObject.SetActive(true);
                gameObject.layer = LayerMask.NameToLayer("Default");
                gameObject.GetComponent<Outline>().enabled = false;
                StartCoroutine(Reactivate(10));
                break;
            case "BonneCharette" :
                player.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = false;
                player.GetComponent<PlayerMovement>().canMove = false;
                player.GetComponent<PlayerMovement>().canInteract = false;
                sousTitres.GetComponent<SoustitresVoices>().ajoutList(156);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(156, player));
                allTextEnviro.transform.GetChild(129).gameObject.SetActive(true);
                gameObject.GetComponent<Outline>().enabled = false;
                break;
        }
    }
    
    private IEnumerator Reactivate(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        yield return null;
    }
    
    private IEnumerator CanInteract(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<PlayerMovement>().canInteract = true;
        yield return null;
    }
    
    private IEnumerator RotationCadenas(float rotationActuelle, float objectif)
    {
        codeInAnim = true;
        float timeElapsed = 0;
        while (timeElapsed < 1) 
        {
            //transform.rotation = Quaternion.Euler(Mathf.Lerp(rotationActuelle,objectif, timeElapsed / 1), transform.rotation.y, 90);
            transform.localRotation = Quaternion.Euler(Mathf.Lerp(rotationActuelle,objectif, timeElapsed / 1), transform.rotation.y, 90);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        //transform.rotation = Quaternion.Euler(objectif, transform.rotation.y, 90);
        transform.localRotation = Quaternion.Euler(objectif, transform.rotation.y, 90);
        codeInAnim = false;
    }
}

public enum PositionCadenas
{
    gauche,
    centre,
    droite
}
