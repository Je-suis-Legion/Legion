using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject player;

    private float purcentageOfScreenDist = 0;
    private Vector2 ratioPixelSize = Vector2.zero;
    private Vector2 screenCenterPoint = Vector2.zero;
    private bool isVisble;
    private Vector2 posOnScreen = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisble)
        {
            //En update si jamais le joueur change la taille de son ecran en jeu.
            ratioPixelSize = new Vector2(Screen.width / 100, Screen.height / 100);
            screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            posOnScreen = player.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Camera>().WorldToScreenPoint(transform.position);
            //Debug.Log(posOnScreen);
            purcentageOfScreenDist = Vector2.Distance(screenCenterPoint, posOnScreen) * 100 / Vector2.Distance(screenCenterPoint, new Vector2(Screen.width, Screen.height));
            /*Debug.Log(Vector2.Distance(screenCenterPoint, posOnScreen));
            Debug.Log(Vector2.Distance(screenCenterPoint, new Vector2(Screen.width, Screen.height)));
            Debug.Log(purcentageOfScreenDist);*/
        }
    }

    private void OnBecameVisible()
    {
        isVisble = true;
        Debug.Log(isVisble);
    }

    private void OnBecameInvisible()
    {
        isVisble = false;
        Debug.Log(isVisble);
    }
}
