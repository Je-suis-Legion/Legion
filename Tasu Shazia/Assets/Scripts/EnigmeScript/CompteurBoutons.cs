using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurBoutons : MonoBehaviour
{
    private GameObject player;
    private GameObject zoneDialogue;
    private GameObject allTextEnviro;
    
    private List<GameObject> listBoutton = new List<GameObject>();
    private List<int> combinaisonCadenas = new List<int>();
    public List<int> codeCadenas;
    private List<GameObject> listCameraZoom = new List<GameObject>();
    public int codeGauche;
    public int codeCentre;
    public int codeDroite;

    private int compteur;

    private void Awake()
    {
        player = GameObject.Find("Player");
        zoneDialogue = GameObject.Find("CanvasPlayer").transform.GetChild(0).GetChild(1).gameObject;
        allTextEnviro = GameObject.Find("CanvasPlayer").transform.GetChild(0).GetChild(3).gameObject;

        foreach (Transform i in transform.GetChild(1))
        {
            listBoutton.Add(i.gameObject);
        }
        
        foreach (Transform i in GameObject.Find("allSymbolesVue").transform)
        {
            listCameraZoom.Add(i.gameObject);
        }
    }

    private void OnEnable()
    {
        combinaisonCadenas.Add(codeGauche);
        combinaisonCadenas.Add(codeCentre);
        combinaisonCadenas.Add(codeDroite);
    }

    public void CheckList()
    {
        compteur = 0;
        
        foreach (var i in listBoutton)
        {
            i.GetComponent<Action>().isInteractible = false;
        }

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
            zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(99);
            StartCoroutine(zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(99, player));
            allTextEnviro.transform.GetChild(93).gameObject.SetActive(true);
            //Effet sonore de clique ? (deverouillage)
            
            transform.GetChild(2).GetChild(0).gameObject.layer = LayerMask.GetMask("Default");
            transform.GetChild(3).GetChild(0).gameObject.layer = LayerMask.GetMask("Default");

            foreach (var i in listCameraZoom)
            {
                i.GetComponent<CameraZoom>().enabled = false;
            }
            gameObject.GetComponent<Animator>().SetBool("Fall", true);
            //Destroy(gameObject);
        }
        
        foreach (var i in listBoutton)
        {
            i.GetComponent<Action>().isInteractible = true;
        }
    }
}
