using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersSon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.name)
        {
            case "AmbianceVille" :
                GameObject.Find("Player").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("Player").transform.GetChild(5).gameObject.SetActive(false);
                break;
            case "AmbianceForet" :
                GameObject.Find("Player").transform.GetChild(5).gameObject.SetActive(true);
                GameObject.Find("Player").transform.GetChild(4).gameObject.SetActive(false);
                break;
        }
    }
}
