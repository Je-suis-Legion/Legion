using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public PositionCadenas positionCadenas;
    public bool isInteractible = true;
    public GameObject cadenas;

    private int code = 1;
    private int codeMax = 6;

    public void ActionEffectuer()
    {
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
    }
}

public enum PositionCadenas
{
    gauche,
    centre,
    droite
}
