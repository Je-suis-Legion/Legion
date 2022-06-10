using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurBoutons : MonoBehaviour
{
    public List<GameObject> listBoutton;
    public List<int> combinaisonCadenas;
    public List<int> codeCadenas;
    public int codeGauche;
    public int codeCentre;
    public int codeDroite;

    private int compteur;

    private void OnEnable()
    {
        combinaisonCadenas.Add(codeGauche);
        combinaisonCadenas.Add(codeCentre);
        combinaisonCadenas.Add(codeDroite);
    }

    public void CheckList()
    {
        compteur = 0;

        for (int i = 0; i < codeCadenas.Count; i++)
        {
            if (codeCadenas[i] == combinaisonCadenas[i])
            {
                compteur++;
            }
        }

        if (compteur == 3)
        {
            foreach (var i in listBoutton)
            {
                i.GetComponent<Action>().isInteractible = false;
            }
            Destroy(gameObject);
            //animation de la chute du cadenas
        }
    }
}
