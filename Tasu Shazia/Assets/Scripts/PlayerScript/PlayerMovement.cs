using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool canMove = true;
    [SerializeField] public List<GameObject> listItem;

    private int layerMaskInteractable;
    private Vector3 velocity;
    private CharacterController controller;
    private GameObject groundCheck;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        layerMaskInteractable = LayerMask.GetMask("Interactable");
        controller = gameObject.GetComponent<CharacterController>();
        groundCheck = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward * 3,Color.red);
        
        //Simulation de la gravité
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        //Mouvements
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        if (canMove)
        {
            controller.Move(move * speed * Time.deltaTime);    
        }
        
        //Raycast pour l'interaction
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, layerMaskInteractable))
        {
            //afficher le msg d'interaction (coroutine pour un fade in fade out
            //Debug.Log(hit.collider.gameObject.name);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("oui");
                if (hit.collider.gameObject.tag == "Inventory")
                {
                    listItem.Add(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                }
                //a completer et tjrs le meme nom de fonction d'action
                //hit.collider.gameObject.GetComponent<SCRIPTDACTION>().FONCTIONDACTION
            }
        }
        
    }
}

public enum EtatJoueur
{
    Normal,
    Odorat,
    Vue,
    Ouie
}
