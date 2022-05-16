using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonsPoussoir : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    private bool isInteractible = true;
    
    private void Push()
    {
        if (isInteractible)
        {
            //inserer code animation du pousser
            obstacle.GetComponent<CompteurBoutons>().listBoutons.Add(gameObject);
            isInteractible = false;
        }
    }
    public void Reset()
    {
        //inserer code animation du retour a l'origin
        isInteractible = true;
    }
}
