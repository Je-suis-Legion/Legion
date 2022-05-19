using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitchYokai : MonoBehaviour
{
    public Yokai yokaiSwitch;
    public GameObject maskYokai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().canMove = false;
            other.gameObject.GetComponent<PlayerYokai>().SwitchYokai(yokaiSwitch, maskYokai);
            other.gameObject.GetComponent<PlayerMovement>().canMove = true;
        }
    }
}

public enum Yokai
{
    Odorat,
    Vue,
    Ouie
}
