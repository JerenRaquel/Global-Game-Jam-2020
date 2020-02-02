using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    public delegate void OnInteraction();
    public static event OnInteraction Interacting;
    
    [Header("Players")]
    public GameObject player1;
    //public Animator animator;

    [Header("Settings")]
    public float speed;
    private float ogSpeed;
    public float dashSpeed;
    public float repairDelay;
    public bool useKeyBoard = false;

    public InputMaster input;   //inputmaster name . action map . action += ctx => func()
    private float dashSpeedCTX = 1;
    private Vector2 movement;
    private Rigidbody2D rb;

    private bool powerUp = false;

    void Awake()
    {
        input = new InputMaster();
        //getting input
        if(useKeyBoard)
            input.Player1.Movement.performed += P1Movement => movement = P1Movement.ReadValue<Vector2>();
        else
            input.Player1.Movement.performed += P1Movement => Move1(P1Movement.ReadValue<Vector2>());
        // input.Player1.Interact.started += ctx => StartCoroutine(Interact());
    }
    
    //starts a loop to keep calling the interacting event until interating is false
    IEnumerator Interact()
    {
        while(true)
        {
            if(Interacting != null)
                Interacting();
            yield return new WaitForSeconds(repairDelay);
        }
    }
    void Start()
    {
        rb = player1.GetComponent<Rigidbody2D>();
        ogSpeed = speed;
        StartCoroutine(Interact());
    }

    //moves the player
    void Move1(Vector2 dir)
    {
        player1.GetComponent<Rigidbody2D>().position += dir * speed * Time.deltaTime * dashSpeedCTX;
        //animator.SetBool("IsMoving", Mathf.Abs(dir.x) > 0 || Mathf.Abs(dir.y) > 0);
    }
    void FixedUpdate()
    {
        if(useKeyBoard)
        {
       // animator.SetBool("IsMoving", Mathf.Abs(movement.x) > 0 || Mathf.Abs(movement.y) > 0);
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
            player1.transform.Translate(movement * speed * Time.deltaTime);
            if(speed != ogSpeed && !powerUp){
                StartCoroutine(PowerUpTime());
                powerUp =  true;
            }
            else if(speed == ogSpeed){
                powerUp = false;
            }
        }
    }

    //needed for unity input system
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    IEnumerator PowerUpTime()
    {
        for(int i = 5; i > 0; i--)
        {
            Debug.Log("Waiting");
            yield return new WaitForSeconds(1);
        }
        speed = ogSpeed;
    }
}
