using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public EtatJoueur etatJoueur;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float distanceInteractions = 3;
    public LayerMask groundMask;
    public bool canMove = false;
    public bool canInteract = false;
    [SerializeField] public List<GameObject> listItem;
    public Canvas canvasJoueur;
    public Sprite interactSprite;

    private int layerMaskInteractable;
    private Vector3 velocity;
    private Vector3 moveDirection;
    private CharacterController controller;
    private GameObject groundCheck;
    private bool isGrounded;
    private Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        //a enlever pour le jeu
        canMove = true;
        canInteract = true;
        //
        layerMaskInteractable = LayerMask.GetMask("Interactable");
        controller = gameObject.GetComponent<CharacterController>();
        groundCheck = transform.GetChild(2).gameObject;
        etatJoueur = EtatJoueur.Normal;
        defaultSprite = canvasJoueur.transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite;
    }

    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward * 3,Color.red);
        
        //Raycast pour l'interaction
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceInteractions, layerMaskInteractable))
        {
            if (canInteract)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    hit.collider.gameObject.GetComponent<Action>().ActionEffectuer();
                }

                canvasJoueur.transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = interactSprite;
                canvasJoueur.transform.GetChild(0).GetChild(2).localScale = new Vector3(0.25f,0.25f,0.25f);
            }
        }
        else
        {
            canvasJoueur.transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = defaultSprite;
            canvasJoueur.transform.GetChild(0).GetChild(2).localScale = new Vector3(0.02f,0.02f,0.02f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    }
}

public enum EtatJoueur
{
    Normal,
    Odorat,
    Vue,
    Ouie
}
