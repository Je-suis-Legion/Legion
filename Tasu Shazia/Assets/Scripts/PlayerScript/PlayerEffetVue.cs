using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerEffetVue : MonoBehaviour
{
    public List<GameObject> listObjetsVue;
    public AudioMixer audioManager;

    private float freqOrigin = 5000f;
    private float freqVue = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveEffetVue()
    {
        foreach (var i in listObjetsVue)
        {
            i.SetActive(true);
        }
        //Peut etre un peu brusque donc voir avec coroutine pour plus smooth
        audioManager.SetFloat("frequenceEffetInGame", freqVue);
        audioManager.SetFloat("frequenceMusiqueInGame", freqVue);
    }
    
    public void DesactiveEffetVue()
    {
        foreach (var i in listObjetsVue)
        {
            i.SetActive(false);
        }
        //Peut etre un peu brusque donc voir avec coroutine pour plus smooth
        audioManager.SetFloat("frequenceEffetInGame", freqOrigin);
        audioManager.SetFloat("frequenceMusiqueInGame", freqOrigin);
    }
}
