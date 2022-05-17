using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYokai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchYokai(Yokai yokai, GameObject mask)
    {
        //code de spawn ou activation du masque + mouvement (rotation et translation)
        //une fois fini
        switch (yokai)
        {
            case Yokai.Odorat:
                gameObject.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Odorat;
                break;
            case Yokai.Ouie:
                gameObject.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Ouie;
                break;
            case Yokai.Vue:
                gameObject.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Vue;
                gameObject.GetComponent<PlayerEffetVue>().ActiveEffetVue();
                break;
        }

    }
}
