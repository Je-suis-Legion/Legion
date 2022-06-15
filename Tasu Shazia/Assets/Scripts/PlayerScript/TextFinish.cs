using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFinish : MonoBehaviour
{
    public GameObject player;
    public GameObject zoneDialogue;
    public GameObject animationMaskOdorat;
    public List<GameObject> listOdaratMat;
    public List<GameObject> listOdeurRouille;
    public List<GameObject> barreAndKey;
    public GameObject animationMaskVue;
    public List<GameObject> listVueMat;
    public List<GameObject> listCodes;
    public GameObject animationMaskOuie;
    public List<GameObject> listOuieMat;
    public Canvas canvasJoueur;

    public void Action(int idText)
    {
        //Penser a ajouter l'apparition / disparition des texts en enviro + triggers
        switch (idText)
        {
            case 5 :
                //Faire un fade in en noir puis enlever la cinematique
                canvasJoueur.transform.GetChild(0).GetChild(2).GetComponent<FadeInOut>().enabled = true;
                //Enlever la cinematique
                //couroutine pour attendre 1 seconde
                StartCoroutine(DelayPlay(6, player, 1));
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(6, player);
                break;
            case 12 :
                canvasJoueur.transform.GetChild(0).GetChild(2).GetComponent<FadeInOut>().enabled = false;
                player.GetComponent<Look>().enabled = true;
                //couroutine pour attendre 1 seconde
                StartCoroutine(DelayPlay(13, player, 1));
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(13, player);
                break;
            case 14 :
                player.GetComponent<PlayerMovement>().canMove = true;
                //couroutine pour attendre 1 seconde
                StartCoroutine(DelayPlay(15, player, 1));
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(15, player);
                break;
            case 30 :
                player.GetComponent<PlayerMovement>().canInteract = true;
                //couroutine pour attendre 1 seconde
                StartCoroutine(DelayPlay(31, player, 1));
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(31, player);
                break;
            case 41 :
                player.GetComponent<Look>().enabled = false;
                player.GetComponent<PlayerMovement>().canMove = false;
                player.GetComponent<PlayerMovement>().canInteract = false;
                player.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Odorat;
                animationMaskOdorat.SetActive(true);
                animationMaskOdorat.GetComponent<Material>().SetFloat("_DissolveAmount", 1.5f);
                foreach (var i in listOdaratMat)
                {
                    StartCoroutine(AppearMaterial(1, 0, 3, i.GetComponent<Material>()));
                }
                StartCoroutine(SwitchYokai(42, player, 8.2f, animationMaskOdorat));
                break;
            case 47 :
                foreach (var i in listOdeurRouille)
                {
                    i.SetActive(true);
                }
                foreach (var i in barreAndKey)
                {
                    i.layer = LayerMask.GetMask("Interactable");
                }
                break;
            case 71 :
                player.GetComponent<Look>().enabled = false;
                player.GetComponent<PlayerMovement>().canMove = false;
                player.GetComponent<PlayerMovement>().canInteract = false;
                player.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Vue;
                animationMaskVue.SetActive(true);
                animationMaskVue.GetComponent<Material>().SetFloat("_DissolveAmount", 1.5f);
                foreach (var i in listVueMat)
                {
                    StartCoroutine(AppearMaterial(1, 0, 3, i.GetComponent<Material>()));
                }
                StartCoroutine(SwitchYokai(72, player, 8.2f, animationMaskVue));
                break;
            case 87 :
                player.GetComponent<PlayerEffetVue>().enabled = true;
                foreach (var i in listCodes)
                {
                    i.GetComponent<CameraZoom>().enabled = true;
                }
                break;
            case 114 :
                player.GetComponent<Look>().enabled = false;
                player.GetComponent<PlayerMovement>().canMove = false;
                player.GetComponent<PlayerMovement>().canInteract = false;
                player.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Ouie;
                animationMaskOuie.SetActive(true);
                animationMaskOuie.GetComponent<Material>().SetFloat("_DissolveAmount", 1.5f);
                foreach (var i in listOuieMat)
                {
                    StartCoroutine(AppearMaterial(1, 0, 3, i.GetComponent<Material>()));
                }
                StartCoroutine(SwitchYokai(115, player, 8.2f, animationMaskOuie));
                break;
            case 156 :
                canvasJoueur.transform.GetChild(0).GetChild(2).GetComponent<FadeInOut>().enabled = true;
                //faire l'inverse mais verifier si le text passe par dessus
                break;
        }
    }
    
    private IEnumerator DelayPlay(int id, GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(id);
        zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(id, obj);
        yield return null;
    }
    
    private IEnumerator SwitchYokai(int id, GameObject obj, float delay, GameObject mask)
    {
        yield return new WaitForSeconds(delay);
        zoneDialogue.GetComponent<SoustitresVoices>().ajoutList(id);
        zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(id, obj);
        player.GetComponent<Look>().enabled = true;
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<PlayerMovement>().canInteract = true;
        mask.SetActive(false);
        yield return null;
    }

    private IEnumerator AppearMaterial(float startDissolve, float endDissolve, float dissolveDuration, Material mat)
    {
        float timeElapsed = 0;
        while (timeElapsed < dissolveDuration) //dissolveDuration étant la durée totale pour dissolve entièrement ton objet
        {
            mat.SetFloat("_DissolveAmount", Mathf.Lerp(startDissolve,endDissolve, timeElapsed / dissolveDuration)); //Ici il faut Get la référence à la varaible du matériaux (En gros c'est le nom de ta variable "DissolveAmount" mais avec un underscore devant
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
        mat.SetFloat("_DissolveAmount", endDissolve);
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(DissolveMaterial(1, 0, 3, mat));
    }
    
    private IEnumerator DissolveMaterial(float startDissolve, float endDissolve, float dissolveDuration, Material mat)
    {
        float timeElapsed = 0;
        while (timeElapsed < dissolveDuration) //dissolveDuration étant la durée totale pour dissolve entièrement ton objet
        {
            mat.SetFloat("_DissolveAmount", Mathf.Lerp(startDissolve,endDissolve, timeElapsed / dissolveDuration)); //Ici il faut Get la référence à la varaible du matériaux (En gros c'est le nom de ta variable "DissolveAmount" mais avec un underscore devant
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
        mat.SetFloat("_DissolveAmount", endDissolve);
    }
}
