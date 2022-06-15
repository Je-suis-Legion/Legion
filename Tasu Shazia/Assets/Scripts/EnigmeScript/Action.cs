using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Action : MonoBehaviour
{
    public GameObject player;
    public GameObject zoneDialogue;

    private bool odeurPorteFirts = true;
    public GameObject odeurBarre;
    public GameObject odeurClef;
    private bool hasClef = false;

    private bool vuePorteFirst = true;
    public PositionCadenas positionCadenas;
    public bool isInteractible = true;
    public GameObject cadenas;
    private int code = 1;
    private int codeMax = 6;

    
    //Penser a ajouter les triggers
    public void ActionEffectuer()
    {
        switch (gameObject.name)
        {
            case "PorteOdeur" :
                if (odeurPorteFirts)
                {
                    zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(47);
                    zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(47, player);
                    odeurPorteFirts = false;
                }
                else
                {
                    if (hasClef)
                    {
                        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(59);
                        zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(59, player);
                        hasClef = false;
                        player.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
                        //activer l'animation du candenas et de la porte
                    }
                    else
                    {
                        int temp = Random.Range(57, 59);
                        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(temp);
                        zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(temp, player);
                    }
                }
                break;
            case "BarreDeFer" :
                player.GetComponent<PlayerMovement>().distanceInteractions = 10;
                player.transform.GetChild(1).GetChild(6).gameObject.SetActive(true);
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(51);
                zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(51, player);
                odeurBarre.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Clef" :
                player.GetComponent<PlayerMovement>().distanceInteractions = 3;
                player.transform.GetChild(1).GetChild(6).gameObject.SetActive(false);
                player.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
                zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(56);
                zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(56, player);
                odeurClef.SetActive(false);
                hasClef = true;
                gameObject.SetActive(false);
                break;
            case "PorteVue" :
                if (vuePorteFirst)
                {
                    zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(87);
                    zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(87, player);
                }
                else
                {
                    if (hasClef)
                    {
                        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(59);
                        zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(59, player);
                        hasClef = false;
                        player.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
                        //activer l'animation du candenas et de la porte
                    }
                    else
                    {
                        int temp = Random.Range(57, 59);
                        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(temp);
                        zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(temp, player);
                    }
                }
                break;
            case "Code1" :
                if (isInteractible)
                {
                    if (code == codeMax)
                    {
                        code = 1;
                    }
                    else
                    {
                        code++;
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
                if (isInteractible)
                {
                    if (code == codeMax)
                    {
                        code = 1;
                    }
                    else
                    {
                        code++;
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
                if (isInteractible)
                {
                    if (code == codeMax)
                    {
                        code = 1;
                    }
                    else
                    {
                        code++;
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
        }
    }
}

public enum PositionCadenas
{
    gauche,
    centre,
    droite
}
