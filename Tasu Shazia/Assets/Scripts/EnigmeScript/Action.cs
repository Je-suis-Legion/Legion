using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    private bool isInteractible = true;
    
    public void ActionEffectuer()
    {
        if (isInteractible)
        {
            //inserer code animation du pousser
            obstacle.GetComponent<CompteurBoutons>().listBoutons.Add(gameObject);
            isInteractible = false;
            obstacle.GetComponent<CompteurBoutons>().CheckList();
        }
    }
    public void Reset()
    {
        //inserer code animation du retour a l'origin
        isInteractible = true;
    }
}
