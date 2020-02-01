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

    [Header("Settings")]
    public float speed;
    public float dashSpeed;
    public float repairDelay;

    public InputMaster input;   //inputmaster name . action map . action += ctx => func()
    private float dashSpeedCTX = 1;
    [HideInInspector]
    public static bool interacting = false;

    void Awake()
    {
        input = new InputMaster();
        //getting input
        input.Player1.Movement.performed += P1Movement => Move1(P1Movement.ReadValue<Vector2>());
        input.Player1.Interact.started += ctx => StartCoroutine(Interact());
    }
    
    IEnumerator Interact()
    {
        interacting = true;
        while(interacting)
        {
            Interacting();
            yield return new WaitForSeconds(repairDelay);
        }
    }

    void Move1(Vector2 dir)
    {
        player1.GetComponent<Rigidbody2D>().position += dir * speed * Time.deltaTime * dashSpeedCTX;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
