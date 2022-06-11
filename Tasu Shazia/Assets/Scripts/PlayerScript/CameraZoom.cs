using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraZoom : MonoBehaviour
{
    public GameObject player;
    public float zoomSpeed = 10;

    [SerializeField]
    private List<GameObject> listSameEffectObject;
    
    private float fovMin = 20;
    private float fovMax = 60;
    private bool isVisble;
    private LensSettings mainCameraSettings;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
    }

    private void FixedUpdate()
    {
        if (isVisble)
        {
            if (player.transform.GetChild(1).GetChild(0).GetComponent<Camera>().fieldOfView > fovMin)
            {
                mainCameraSettings = LensSettings.FromCamera(player.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Camera>());
                player.transform.GetChild(1).GetChild(1).gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens =
                    new LensSettings(mainCameraSettings.FieldOfView - zoomSpeed * Time.deltaTime,
                        mainCameraSettings.OrthographicSize,mainCameraSettings.NearClipPlane,
                        mainCameraSettings.FarClipPlane,mainCameraSettings.Dutch);
                //Debug.Log(mainCameraSettings.FieldOfView);
            }
        }
        else
        {
            if (player.transform.GetChild(1).GetChild(0).GetComponent<Camera>().fieldOfView < fovMax)
            {
                mainCameraSettings = LensSettings.FromCamera(player.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Camera>());
                player.transform.GetChild(1).GetChild(1).gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens =
                    new LensSettings(mainCameraSettings.FieldOfView + zoomSpeed * Time.deltaTime,
                        mainCameraSettings.OrthographicSize,mainCameraSettings.NearClipPlane,
                        mainCameraSettings.FarClipPlane,mainCameraSettings.Dutch);
                //Debug.Log(mainCameraSettings.FieldOfView);
            }
        }
    }

    private void OnBecameVisible()
    {
        isVisble = true;
        foreach (var i in listSameEffectObject)
        {
            if (i != gameObject)
            {
                i.GetComponent<CameraZoom>().enabled = false;
            }
        }
    }

    private void OnBecameInvisible()
    {
        isVisble = false;
        foreach (var i in listSameEffectObject)
        {
            if (i != gameObject)
            {
                i.GetComponent<CameraZoom>().enabled = true;
            }
        }
    }
}
