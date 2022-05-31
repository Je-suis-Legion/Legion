using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public int idText;
    public GameObject originSonore;
    public GameObject zoneText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        zoneText.GetComponent<SoustitresVoices>().SoustitreVoice(idText,originSonore);
    }
}
