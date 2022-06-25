using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TextFinish : MonoBehaviour
{
    public Material screenEffectMat;
    
    private GameObject canvasPlayer;
    private GameObject sousTitres;
    private GameObject animationMaskOdorat;
    public List<GameObject> listOdaratMat;
    private GameObject animationMaskVue;
    public List<GameObject> listVueMat;
    private GameObject animationMaskOuie;
    public List<GameObject> listOuieMat;
    private List<GameObject> listTriggerMaison = new List<GameObject>();
    private GameObject allTextEnviro;
    private GameObject allTriggerText;

    private void Awake()
    {
        canvasPlayer = GameObject.Find("CanvasPlayer");
        sousTitres = canvasPlayer.transform.GetChild(0).GetChild(2).gameObject;
        animationMaskOdorat = transform.GetChild(1).GetChild(3).gameObject;
        animationMaskVue = transform.GetChild(1).GetChild(4).gameObject;
        animationMaskOuie = transform.GetChild(1).GetChild(5).gameObject;
        allTextEnviro = GameObject.Find("AllTextEnvironmentaux");
        allTriggerText = GameObject.Find("AllTextTrigger");
        
        foreach (Transform i in GameObject.Find("allInteractable").transform.GetChild(7))
        {
            listTriggerMaison.Add(i.gameObject);
        }
        
        screenEffectMat.SetFloat("_FullscreenIntensity", 0);
    }

    public void Action(int idText)
    {
        int temp;
        int id = idText;
        //voir si on garde les 1 sec de plus de delay ou si c a la suite
        //Penser a ajouter l'apparition / disparition des texts en enviro + triggers
        switch (idText)
        {
            case 5 :
                //Faire un fade in en noir puis enlever la cinematique
                canvasPlayer.transform.GetChild(0).GetChild(1).GetComponent<FadeInOut>().enabled = true;
                canvasPlayer.transform.GetChild(0).GetChild(0).GetComponent<FadeInOutVideo>().enabled = false;
                //Enlever la cinematique
                //couroutine pour attendre 1 seconde
                StartCoroutine(DelayPlay(6, gameObject, 1));
                //GameObject.Find("=======UI=======").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).GetChild(1).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(0).GetChild(2).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(1).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(2).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(2).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(3).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(3).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(3).GetChild(1).gameObject.GetComponent<FadeInOutText>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(4).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(4).GetChild(0).gameObject.GetComponent<FadeInOut>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(4).GetChild(1).gameObject.GetComponent<FadeInOutText>().enabled = true;
                GameObject.Find("=======UI=======").transform.GetChild(4).GetChild(5).gameObject.GetComponent<FadeInOut>().enabled = true;
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(6, player);
                transform.GetChild(3).GetComponent<AudioSource>().Play();
                transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 9 :
                StartCoroutine(DelayPlay(12, gameObject, 0.1f));
                //sousTitres.GetComponent<SoustitresVoices>().ajoutList(12);
                //StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(12, gameObject));
                break;
            case 12 :
                allTextEnviro.transform.GetChild(0).gameObject.SetActive(true);
                canvasPlayer.transform.GetChild(0).GetChild(1).GetComponent<FadeInOut>().enabled = false;
                gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = true;
                //couroutine pour attendre 1 seconde
                /*sousTitres.GetComponent<SoustitresVoices>().ajoutList(13);
                StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(13, gameObject));*/
                StartCoroutine(DelayPlay(13, gameObject, 0.1f));
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(13, player);
                break;
            /*case 13:
                allTextEnviro.transform.GetChild(0).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(1).gameObject.SetActive(true);
                break;*/
            case 14 :
                allTextEnviro.transform.GetChild(1).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(3).gameObject.SetActive(true);
                gameObject.GetComponent<PlayerMovement>().canMove = true;
                //couroutine pour attendre 1 seconde
                //sousTitres.GetComponent<SoustitresVoices>().ajoutList(16);
                //StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(16, gameObject));
                StartCoroutine(DelayPlay(16, gameObject, 0.1f));
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(15, player);
                break;
            case 13 or 
                >= 15 and <= 18 or >=21 and <= 29 or 32 or
                >= 34 and <= 37 or 39 or 40 or
                >= 42 and <= 45 or
                >= 47 and <= 49 or
                51 or 52 or 54 or 59 or 60 or 63 or 68 or 69 or 71 or
                72 or 73 :
                allTextEnviro.transform.GetChild(id - 13).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(id - 12).gameObject.SetActive(true);
                break;
            case 19 :
                StartCoroutine(DelayPlay(21, gameObject, 0.1f));
                //sousTitres.GetComponent<SoustitresVoices>().ajoutList(21);
                //StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(21, gameObject));
                allTextEnviro.transform.GetChild(id - 13).gameObject.GetComponent<TextEnvironnemental>().Disable();
                //allTextEnviro.transform.GetChild(id - 12).gameObject.SetActive(true);
                break;
                /*allTextEnviro.transform.GetChild(2).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 16 :
                allTextEnviro.transform.GetChild(3).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 17 :
                allTextEnviro.transform.GetChild(4).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 18 :
                allTextEnviro.transform.GetChild(5).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(6).gameObject.SetActive(true);
                break;
            case 19 :
                allTextEnviro.transform.GetChild(6).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(7).gameObject.SetActive(true);
                break;
            case 20 :
                allTextEnviro.transform.GetChild(7).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(8).gameObject.SetActive(true);
                break;
            case 21 :
                allTextEnviro.transform.GetChild(8).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(9).gameObject.SetActive(true);
                break;
            case 22 :
                allTextEnviro.transform.GetChild(9).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(10).gameObject.SetActive(true);
                break;
            case 23 :
                allTextEnviro.transform.GetChild(10).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(11).gameObject.SetActive(true);
                break;
            case 24 :
                allTextEnviro.transform.GetChild(11).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(12).gameObject.SetActive(true);
                break;
            case 25 :
                allTextEnviro.transform.GetChild(12).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(13).gameObject.SetActive(true);
                break;
            case 26 :
                allTextEnviro.transform.GetChild(13).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(14).gameObject.SetActive(true);
                break;
            case 27 :
                allTextEnviro.transform.GetChild(14).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(15).gameObject.SetActive(true);
                break;
            case 28 :
                allTextEnviro.transform.GetChild(15).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(16).gameObject.SetActive(true);
                break;
            case 29 :
                allTextEnviro.transform.GetChild(16).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(17).gameObject.SetActive(true);
                break;*/
            case 30 :
                allTextEnviro.transform.GetChild(17).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(18).gameObject.SetActive(true);
                gameObject.GetComponent<PlayerMovement>().canInteract = true;
                GameObject.Find("allInteractable").transform.GetChild(0).GetChild(0).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(0).GetChild(1).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(0).GetChild(2).GetComponent<Outline>().enabled =
                    true;
                //couroutine pour attendre 1 seconde
                StartCoroutine(DelayPlay(31, gameObject, 1));
                //zoneDialogue.GetComponent<SoustitresVoices>().SoustitreVoice(31, player);
                break;
            case 31 or 33 or 38 or 46 or 53 or
                >= 55 and <= 58 or
                61 or 62 or
                >= 64 and <= 66 or
                134:
                allTextEnviro.transform.GetChild(id - 13).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            /*case 32 :
                allTextEnviro.transform.GetChild(19).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(20).gameObject.SetActive(true);
                break;
            case 33 :
                allTextEnviro.transform.GetChild(20).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 34 :
                allTextEnviro.transform.GetChild(21).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(22).gameObject.SetActive(true);
                break;
            case 35 :
                allTextEnviro.transform.GetChild(22).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(23).gameObject.SetActive(true);
                break;
            case 36 :
                allTextEnviro.transform.GetChild(23).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(24).gameObject.SetActive(true);
                break;
            case 37 :
                allTextEnviro.transform.GetChild(24).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(25).gameObject.SetActive(true);
                break;
            case 38 :
                allTextEnviro.transform.GetChild(25).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 39 :
                allTextEnviro.transform.GetChild(26).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(27).gameObject.SetActive(true);
                break;
            case 40 :
                allTextEnviro.transform.GetChild(27).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(28).gameObject.SetActive(true);
                break;*/
            case 41 :
                gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = false;
                gameObject.GetComponent<PlayerMovement>().canMove = false;
                gameObject.GetComponent<PlayerMovement>().canInteract = false;
                gameObject.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Odorat;
                allTextEnviro.transform.GetChild(28).gameObject.GetComponent<TextEnvironnemental>().Disable();
                GameObject.Find("allInteractable").transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(2).GetChild(2).GetChild(0).gameObject.layer =
                    LayerMask.NameToLayer("Interactable");
                /*GameObject.Find("allInteractable").transform.GetChild(5).GetChild(1).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(5).GetChild(1).gameObject.layer =
                    LayerMask.NameToLayer("Interactable");*/
                animationMaskOdorat.SetActive(true);
                //animationMaskOdorat.GetComponent<Material>().SetFloat("_DissolveAmount", 1.5f);
                foreach (var i in listOdaratMat)
                {
                    StartCoroutine(AppearMaterial(1, 0, 3, i.GetComponent<MeshRenderer>().material, 6.2f));
                }
                StartCoroutine(SwitchYokai(42, gameObject, 12f, animationMaskOdorat, 29));
                break;
            /*case 42 :
                allTextEnviro.transform.GetChild(29).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(30).gameObject.SetActive(true);
                break;
            case 43 :
                allTextEnviro.transform.GetChild(30).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(31).gameObject.SetActive(true);
                break;
            case 44 :
                allTextEnviro.transform.GetChild(31).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(32).gameObject.SetActive(true);
                break;
            case 45 :
                allTextEnviro.transform.GetChild(32).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(33).gameObject.SetActive(true);
                break;
            case 46 :
                allTextEnviro.transform.GetChild(33).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 47 :
                allTextEnviro.transform.GetChild(34).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(35).gameObject.SetActive(true);
                break;
            case 48 :
                allTextEnviro.transform.GetChild(35).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(36).gameObject.SetActive(true);
                break;
            case 49 :
                allTextEnviro.transform.GetChild(36).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(37).gameObject.SetActive(true);
                break;*/
            case 50 :
                allTextEnviro.transform.GetChild(37).gameObject.GetComponent<TextEnvironnemental>().Disable();
                
                allTriggerText.transform.GetChild(2).gameObject.SetActive(true);
                
                break;
            case 67 :
                gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = false;
                gameObject.GetComponent<PlayerMovement>().canMove = false;
                gameObject.GetComponent<PlayerMovement>().canInteract = false;
                allTextEnviro.transform.GetChild(id - 13).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(id - 12).gameObject.SetActive(true);
                break;
            /*case 51 :
                allTextEnviro.transform.GetChild(38).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(39).gameObject.SetActive(true);
                break;
            case 52 :
                allTextEnviro.transform.GetChild(39).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(40).gameObject.SetActive(true);
                break;
            case 53 :
                allTextEnviro.transform.GetChild(40).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 54 :
                allTextEnviro.transform.GetChild(41).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(42).gameObject.SetActive(true);
                break;
            case 55 :
                allTextEnviro.transform.GetChild(42).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 56 :
                allTextEnviro.transform.GetChild(43).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 57 :
                allTextEnviro.transform.GetChild(44).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 58 :
                allTextEnviro.transform.GetChild(45).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 59 :
                allTextEnviro.transform.GetChild(46).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(47).gameObject.SetActive(true);
                break;
            case 60 :
                allTextEnviro.transform.GetChild(47).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(48).gameObject.SetActive(true);
                break;
            case 61 :
                allTextEnviro.transform.GetChild(48).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 62 :
                allTextEnviro.transform.GetChild(49).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 63 :
                allTextEnviro.transform.GetChild(50).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(51).gameObject.SetActive(true);
                break;
            case 64 :
                allTextEnviro.transform.GetChild(51).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 65 :
                allTextEnviro.transform.GetChild(52).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 66 :
                allTextEnviro.transform.GetChild(53).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 67 :
                allTextEnviro.transform.GetChild(54).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(55).gameObject.SetActive(true);
                break;
            case 68 :
                allTextEnviro.transform.GetChild(55).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(56).gameObject.SetActive(true);
                break;
            case 69 :
                allTextEnviro.transform.GetChild(56).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(57).gameObject.SetActive(true);
                break;
            case 70 :
                allTextEnviro.transform.GetChild(57).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(58).gameObject.SetActive(true);
                break;*/
            case 70 :
                /*gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = false;
                gameObject.GetComponent<PlayerMovement>().canMove = false;
                gameObject.GetComponent<PlayerMovement>().canInteract = false;*/
                gameObject.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Vue;
                allTextEnviro.transform.GetChild(57).gameObject.GetComponent<TextEnvironnemental>().Disable();
                animationMaskVue.SetActive(true);
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(1).GetChild(0).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(1).GetChild(0).gameObject.layer =
                    LayerMask.NameToLayer("Interactable");
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(1).GetChild(1).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(1).GetChild(1).gameObject.layer =
                    LayerMask.NameToLayer("Interactable");
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(1).GetChild(2).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(1).GetChild(2).gameObject.layer =
                    LayerMask.NameToLayer("Interactable");
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(2).GetChild(0).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(2).GetChild(0).gameObject.layer =
                    LayerMask.NameToLayer("Interactable");
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(3).GetChild(0).GetComponent<Outline>().enabled =
                    true;
                GameObject.Find("allInteractable").transform.GetChild(6).GetChild(3).GetChild(0).gameObject.layer =
                    LayerMask.NameToLayer("Interactable");
                //animationMaskVue.GetComponent<Material>().SetFloat("_DissolveAmount", 1.5f);
                foreach (var i in listVueMat)
                {
                    StartCoroutine(AppearMaterial(1, 0, 3, i.GetComponent<MeshRenderer>().material, 2.2f));
                }
                StartCoroutine(SwitchYokai(71, gameObject, 8.2f, animationMaskVue, 58));
                break;
            /*case 72 :
                allTextEnviro.transform.GetChild(59).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(60).gameObject.SetActive(true);
                break;
            case 73 :
                allTextEnviro.transform.GetChild(60).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(61).gameObject.SetActive(true);
                break;*/
            case 74 :
                allTextEnviro.transform.GetChild(61).gameObject.GetComponent<TextEnvironnemental>().Disable();
                
                /*allTriggerText.transform.GetChild(8).gameObject.SetActive(true);
                allTriggerText.transform.GetChild(9).gameObject.SetActive(true);
                allTriggerText.transform.GetChild(10).gameObject.SetActive(true);
                allTriggerText.transform.GetChild(11).gameObject.SetActive(true);
                allTriggerText.transform.GetChild(12).gameObject.SetActive(true);
                allTriggerText.transform.GetChild(13).gameObject.SetActive(true);
                allTriggerText.transform.GetChild(14).gameObject.SetActive(true);*/
                
                break;
            case 75 :
                allTextEnviro.transform.GetChild(62).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(63).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(64).gameObject.SetActive(true);
                allTextEnviro.transform.GetChild(65).gameObject.SetActive(true);
                break;
            case 76 :
                allTextEnviro.transform.GetChild(64).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(65).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(66).gameObject.SetActive(true);
                allTextEnviro.transform.GetChild(67).gameObject.SetActive(true);
                break;
            case 77 :
                allTextEnviro.transform.GetChild(66).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(67).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(68).gameObject.SetActive(true);
                allTextEnviro.transform.GetChild(69).gameObject.SetActive(true);
                break;
            case 78 :
                allTextEnviro.transform.GetChild(68).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(69).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(70).gameObject.SetActive(true);
                allTextEnviro.transform.GetChild(71).gameObject.SetActive(true);
                break;
            case 79 :
                allTextEnviro.transform.GetChild(70).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(71).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(72).gameObject.SetActive(true);
                allTextEnviro.transform.GetChild(73).gameObject.SetActive(true);
                break;
            case 80 :
                allTextEnviro.transform.GetChild(72).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(73).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(74).gameObject.SetActive(true);
                allTextEnviro.transform.GetChild(75).gameObject.SetActive(true);
                break;
            case 81 :
                allTextEnviro.transform.GetChild(74).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(75).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case >=82 and <= 85 or
                >= 87 and <= 90 or 
                92 or 99 or 101 or 104 or
                >= 106 and <= 108 or
                /*112 or*/ 113 or 114 or
                >= 115 and <= 118 or
                120 or 122 or 123 :
                allTextEnviro.transform.GetChild(id - 6).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(id - 5).gameObject.SetActive(true);
                break;
            /*case 83 :
                allTextEnviro.transform.GetChild(77).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(78).gameObject.SetActive(true);
                break;
            case 84 :
                allTextEnviro.transform.GetChild(78).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(79).gameObject.SetActive(true);
                break;
            case 85 :
                allTextEnviro.transform.GetChild(79).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(80).gameObject.SetActive(true);
                break;*/
            case 86 or 91 or 93 or 94 or 98 or 100 or 102 or 103 or 105 or 109 or 110 or 121 or 124 :
                allTextEnviro.transform.GetChild(id - 6).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            /*case 87 :
                allTextEnviro.transform.GetChild(81).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(82).gameObject.SetActive(true);
                break;
            case 88 :
                allTextEnviro.transform.GetChild(82).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(83).gameObject.SetActive(true);
                break;
            case 89 :
                allTextEnviro.transform.GetChild(83).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(84).gameObject.SetActive(true);
                break;
            case 90 :
                allTextEnviro.transform.GetChild(84).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(85).gameObject.SetActive(true);
                break;
            case 91 :
                allTextEnviro.transform.GetChild(85).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 92 :
                allTextEnviro.transform.GetChild(86).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(87).gameObject.SetActive(true);
                break;
            case 93 :
                allTextEnviro.transform.GetChild(87).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 94 :
                allTextEnviro.transform.GetChild(88).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 98 :
                allTextEnviro.transform.GetChild(92).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 99 :
                allTextEnviro.transform.GetChild(93).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(94).gameObject.SetActive(true);
                break;
            case 100 :
                allTextEnviro.transform.GetChild(94).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 101 :
                allTextEnviro.transform.GetChild(95).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(96).gameObject.SetActive(true);
                break;
            case 102 :
                allTextEnviro.transform.GetChild(96).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 103 :
                allTextEnviro.transform.GetChild(97).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 104 :
                allTextEnviro.transform.GetChild(98).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(99).gameObject.SetActive(true);
                break;
            case 105 :
                allTextEnviro.transform.GetChild(99).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 106 :
                allTextEnviro.transform.GetChild(100).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(101).gameObject.SetActive(true);
                break;
            case 107 :
                allTextEnviro.transform.GetChild(101).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(102).gameObject.SetActive(true);
                break;
            case 108 :
                allTextEnviro.transform.GetChild(102).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(103).gameObject.SetActive(true);
                break;
            case 109 :
                allTextEnviro.transform.GetChild(103).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 110 :
                allTextEnviro.transform.GetChild(104).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;*/
            case 111 :
                allTextEnviro.transform.GetChild(105).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(106).gameObject.SetActive(true);
                
                allTriggerText.transform.GetChild(12).gameObject.SetActive(false);
                allTriggerText.transform.GetChild(13).gameObject.SetActive(false);
                allTriggerText.transform.GetChild(14).gameObject.SetActive(false);
                
                break;
            case 112 :
                gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = false;
                gameObject.GetComponent<PlayerMovement>().canMove = false;
                gameObject.GetComponent<PlayerMovement>().canInteract = false;
                allTextEnviro.transform.GetChild(106).gameObject.GetComponent<TextEnvironnemental>().Disable();
                gameObject.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Ouie;
                animationMaskOuie.SetActive(true);
                //animationMaskOuie.GetComponent<Material>().SetFloat("_DissolveAmount", 1.5f);
                foreach (var i in listOuieMat)
                {
                    StartCoroutine(AppearMaterial(1, 0, 3, i.GetComponent<MeshRenderer>().material, 6.2f));
                }
                StartCoroutine(SwitchYokai(113, gameObject, 12f, animationMaskOuie, 107));
                break;
            /*case 113 :
                allTextEnviro.transform.GetChild(107).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(108).gameObject.SetActive(true);
                break;*/
            /*case 114 :
                /*gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = false;
                gameObject.GetComponent<PlayerMovement>().canMove = false;
                gameObject.GetComponent<PlayerMovement>().canInteract = false;*/
                //gameObject.GetComponent<PlayerMovement>().etatJoueur = EtatJoueur.Ouie;
                allTextEnviro.transform.GetChild(108).gameObject.GetComponent<TextEnvironnemental>().Disable();
                /*animationMaskOuie.SetActive(true);
                //animationMaskOuie.GetComponent<Material>().SetFloat("_DissolveAmount", 1.5f);
                foreach (var i in listOuieMat)
                {
                    StartCoroutine(AppearMaterial(1, 0, 3, i.GetComponent<MeshRenderer>().material));
                }
                StartCoroutine(SwitchYokai(115, gameObject, 12f, animationMaskOuie, 109));*/
                break;
            /*case 115 :
                allTextEnviro.transform.GetChild(109).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(110).gameObject.SetActive(true);
                break;
            case 116 :
                allTextEnviro.transform.GetChild(110).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(111).gameObject.SetActive(true);
                break;
            case 117 :
                allTextEnviro.transform.GetChild(111).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(112).gameObject.SetActive(true);
                break;
            case 118 :
                allTextEnviro.transform.GetChild(112).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(113).gameObject.SetActive(true);
                break;*/
            case 119 :
                allTextEnviro.transform.GetChild(113).gameObject.GetComponent<TextEnvironnemental>().Disable();
                foreach (var i in listTriggerMaison)
                {
                    i.SetActive(true);
                }
                
                allTriggerText.transform.GetChild(16).gameObject.SetActive(true);
                allTriggerText.transform.GetChild(17).gameObject.SetActive(true);
                
                break;
            /*case 120 :
                allTextEnviro.transform.GetChild(114).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(115).gameObject.SetActive(true);
                break;
            case 121 :
                allTextEnviro.transform.GetChild(115).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 122 :
                allTextEnviro.transform.GetChild(116).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(117).gameObject.SetActive(true);
                break;
            case 123 :
                allTextEnviro.transform.GetChild(117).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(118).gameObject.SetActive(true);
                break;
            case 124 :
                allTextEnviro.transform.GetChild(118).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;*/
            case 125 :
                allTextEnviro.transform.GetChild(119).gameObject.SetActive(true);
                break;
            case 126 :
                allTextEnviro.transform.GetChild(119).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 128 or 135 :
                temp = Random.Range(152, 154);
                StartCoroutine(DelayPlay(temp, gameObject, 1));
                switch (temp)
                {
                    case 152 :
                        allTextEnviro.transform.GetChild(125).gameObject.SetActive(true);
                        break;
                    case 153 :
                        allTextEnviro.transform.GetChild(126).gameObject.SetActive(true);
                        break;
                }
                break;
            case 131 :
                allTextEnviro.transform.GetChild(120).gameObject.SetActive(true);
                break;
            case 132 :
                allTextEnviro.transform.GetChild(120).gameObject.GetComponent<TextEnvironnemental>().Disable();
                temp = Random.Range(152, 154);
                StartCoroutine(DelayPlay(temp, gameObject, 1));
                switch (temp)
                {
                    case 152 :
                        allTextEnviro.transform.GetChild(125).gameObject.SetActive(true);
                        break;
                    case 153 :
                        allTextEnviro.transform.GetChild(126).gameObject.SetActive(true);
                        break;
                }
                break;
            case 133 :
                allTextEnviro.transform.GetChild(121).gameObject.SetActive(true);
                break;
            /*case 134 :
                allTextEnviro.transform.GetChild(121).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 135 :
                temp = Random.Range(152, 154);
                StartCoroutine(DelayPlay(temp, player, 1));
                switch (temp)
                {
                    case 152 :
                        allTextEnviro.transform.GetChild(125).gameObject.SetActive(true);
                        break;
                    case 153 :
                        allTextEnviro.transform.GetChild(126).gameObject.SetActive(true);
                        break;
                }
                break;*/
            case 138 :
                allTextEnviro.transform.GetChild(122).gameObject.SetActive(true);
                break;
            case 139 :
                allTextEnviro.transform.GetChild(122).gameObject.GetComponent<TextEnvironnemental>().Disable();
                temp = Random.Range(152, 154);
                StartCoroutine(DelayPlay(temp, gameObject, 1));
                switch (temp)
                {
                    case 152 :
                        allTextEnviro.transform.GetChild(125).gameObject.SetActive(true);
                        break;
                    case 153 :
                        allTextEnviro.transform.GetChild(126).gameObject.SetActive(true);
                        break;
                }
                break;
            case 141 :
                allTextEnviro.transform.GetChild(123).gameObject.SetActive(true);
                break;
            case 142 :
                allTextEnviro.transform.GetChild(123).gameObject.GetComponent<TextEnvironnemental>().Disable();
                temp = Random.Range(152, 154);
                StartCoroutine(DelayPlay(temp, gameObject, 1));
                switch (temp)
                {
                    case 152 :
                        allTextEnviro.transform.GetChild(125).gameObject.SetActive(true);
                        break;
                    case 153 :
                        allTextEnviro.transform.GetChild(126).gameObject.SetActive(true);
                        break;
                }
                break;
            case 145 :
                allTextEnviro.transform.GetChild(124).gameObject.SetActive(true);
                break;
            case 146 :
                allTextEnviro.transform.GetChild(124).gameObject.GetComponent<TextEnvironnemental>().Disable();
                temp = Random.Range(152, 154);
                StartCoroutine(DelayPlay(temp, gameObject, 1));
                switch (temp)
                {
                    case 152 :
                        allTextEnviro.transform.GetChild(125).gameObject.SetActive(true);
                        break;
                    case 153 :
                        allTextEnviro.transform.GetChild(126).gameObject.SetActive(true);
                        break;
                }
                break;
            case >= 148 and <= 151 :
                temp = Random.Range(154, 156);
                StartCoroutine(DelayPlay(temp, gameObject, 1));
                switch (temp)
                {
                    case 154 :
                        allTextEnviro.transform.GetChild(127).gameObject.SetActive(true);
                        break;
                    case 155 :
                        allTextEnviro.transform.GetChild(128).gameObject.SetActive(true);
                        break;
                }
                break;
            /*case 149 :
                temp = Random.Range(154, 156);
                StartCoroutine(DelayPlay(temp, player, 1));
                switch (temp)
                {
                    case 154 :
                        allTextEnviro.transform.GetChild(127).gameObject.SetActive(true);
                        break;
                    case 155 :
                        allTextEnviro.transform.GetChild(128).gameObject.SetActive(true);
                        break;
                }
                break;
            case 150 :
                temp = Random.Range(154, 156);
                StartCoroutine(DelayPlay(temp, player, 1));
                switch (temp)
                {
                    case 154 :
                        allTextEnviro.transform.GetChild(127).gameObject.SetActive(true);
                        break;
                    case 155 :
                        allTextEnviro.transform.GetChild(128).gameObject.SetActive(true);
                        break;
                }
                break;
            case 151 :
                temp = Random.Range(154, 156);
                StartCoroutine(DelayPlay(temp, player, 1));
                switch (temp)
                {
                    case 154 :
                        allTextEnviro.transform.GetChild(127).gameObject.SetActive(true);
                        break;
                    case 155 :
                        allTextEnviro.transform.GetChild(128).gameObject.SetActive(true);
                        break;
                }
                break;*/
            case >=152 and <= 155 or
                161 :
                allTextEnviro.transform.GetChild(id - 27).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            /*case 153 :
                allTextEnviro.transform.GetChild(126).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 154 :
                allTextEnviro.transform.GetChild(127).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;
            case 155 :
                allTextEnviro.transform.GetChild(128).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;*/
            case 156 :
                canvasPlayer.transform.GetChild(0).GetChild(1).GetComponent<FadeInOut>().enabled = true;
                canvasPlayer.transform.GetChild(0).GetChild(3).GetComponent<Image>().enabled = false;
                allTextEnviro.transform.GetChild(129).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(130).gameObject.SetActive(true);
                //pop de la cinematique
                break;
            case 157 :
                //canvasPlayer.transform.GetChild(0).GetChild(1).GetComponent<FadeInOut>().enabled = false;
                allTextEnviro.transform.GetChild(130).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(131).gameObject.SetActive(true);
                break;
            case 158 or 159 :
                allTextEnviro.transform.GetChild(id - 27).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(id - 26).gameObject.SetActive(true);
                break;
            /*case 159 :
                allTextEnviro.transform.GetChild(132).gameObject.GetComponent<TextEnvironnemental>().Disable();
                allTextEnviro.transform.GetChild(133).gameObject.SetActive(true);
                break;*/
            case 160 :
                allTextEnviro.transform.GetChild(133).gameObject.GetComponent<TextEnvironnemental>().Disable();
                canvasPlayer.transform.GetChild(0).GetChild(5).gameObject.GetComponent<FadeInOut>().enabled = true;
                canvasPlayer.transform.GetChild(0).GetChild(4).gameObject.GetComponent<FadeInOutTextMesh>().enabled = true;
                canvasPlayer.transform.GetChild(0).GetChild(6).gameObject.GetComponent<FadeInOutTextMesh>().enabled = true;
                Cursor.lockState = CursorLockMode.None;
                screenEffectMat.SetFloat("_FullscreenIntensity", 0);
                StartCoroutine(goBackMenu(6));
                break;
            /*case 161 :
                allTextEnviro.transform.GetChild(134).gameObject.GetComponent<TextEnvironnemental>().Disable();
                break;*/
        }
    }
    
    private IEnumerator DelayPlay(int id, GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        sousTitres.GetComponent<SoustitresVoices>().ajoutList(id);
        StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(id, obj));
        yield return null;
    }
    
    private IEnumerator SwitchYokai(int id, GameObject obj, float delay, GameObject mask, int textEnviroChild)
    {
        yield return new WaitForSeconds(delay);

        if (screenEffectMat.GetFloat("_FullscreenIntensity") != 0.15f)
        {
            screenEffectMat.SetFloat("_FullscreenIntensity", 0.15f);
        }
        Debug.Log("enter : " + mask.name);
        switch (mask.name)
        {
            case "MaskOdorat" :
                screenEffectMat.color = new Color(148,0,211);
                Debug.Log(screenEffectMat.color);
                break;
            case "MaskVue" :
                screenEffectMat.color = new Color(0,0,255);
                Debug.Log(screenEffectMat.color);
                break;
            case "MaskOuie" :
                screenEffectMat.color = new Color(0,255,0);
                Debug.Log(screenEffectMat.color);
                break;
        }
        
        sousTitres.GetComponent<SoustitresVoices>().ajoutList(id);
        StartCoroutine(sousTitres.GetComponent<SoustitresVoices>().SoustitreVoice(id, obj));
        allTextEnviro.transform.GetChild(textEnviroChild).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Look>().enabled = true;
        gameObject.GetComponent<PlayerMovement>().canMove = true;
        gameObject.GetComponent<PlayerMovement>().canInteract = true;
        mask.SetActive(false);
        yield return null;
    }

    private IEnumerator AppearMaterial(float startDissolve, float endDissolve, float dissolveDuration, Material mat, float wait)
    {
        float timeElapsed = 0;
        while (timeElapsed < dissolveDuration) //dissolveDuration étant la durée totale pour dissolve entièrement ton objet
        {
            mat.SetFloat("_DissolveAmount", Mathf.Lerp(startDissolve,endDissolve, timeElapsed / dissolveDuration)); //Ici il faut Get la référence à la varaible du matériaux (En gros c'est le nom de ta variable "DissolveAmount" mais avec un underscore devant
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(wait);
        StartCoroutine(DissolveMaterial(0, 1, 3, mat));
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

    private IEnumerator goBackMenu(float delay)
    {
        yield return new WaitForSeconds(1);
        transform.GetChild(3).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(delay - 1);
        SceneManager.LoadScene(0);
    }
}