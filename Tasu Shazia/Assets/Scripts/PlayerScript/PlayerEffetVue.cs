using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerEffetVue : MonoBehaviour
{
    public List<GameObject> listObjetsVue;
    public AudioMixer audioManager;

    private float freqOrigin = 5000f;
    private float freqVue = 1000f;

    private void OnEnable()
    {
        foreach (var i in listObjetsVue)
        {
            i.gameObject.GetComponent<Outline>().enabled = true;
        }
        //Peut etre un peu brusque donc voir avec coroutine pour plus smooth
        /*audioManager.SetFloat("frequenceEffetInGame", freqVue);
        audioManager.SetFloat("frequenceMusiqueInGame", freqVue);
        audioManager.SetFloat("frequenceDialoguesInGame", freqVue);*/
    }

    private void OnDisable()
    {
        foreach (var i in listObjetsVue)
        {
            i.gameObject.GetComponent<Outline>().enabled = false;
        }
        //Peut etre un peu brusque donc voir avec coroutine pour plus smooth
        /*audioManager.SetFloat("frequenceEffetInGame", freqOrigin);
        audioManager.SetFloat("frequenceMusiqueInGame", freqOrigin);
        audioManager.SetFloat("frequenceDialoguesInGame", freqOrigin);*/
    }
}
