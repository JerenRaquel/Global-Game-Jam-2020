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
    // public GameObject player2;

    [Header("Settings")]
    public float speed;
    public float dashSpeed;
    public float repairDelay;

    public InputMaster input;
    private float dashSpeedCTX = 1;
    [HideInInspector]
    public static bool interacting = false;

    void Awake()
    {
        input = new InputMaster();
        input.Player1.Movement.performed += P1Movement => Move1(P1Movement.ReadValue<Vector2>());
        input.Player1.Interact.started += ctx => StartCoroutine(Interact());
        // input.Player2.Movement.performed += P2Movement => Move2(P2Movement.ReadValue<Vector2>());
        // input.Player1.Movement.canceled += P1Movement => EndDaWsh();
        // input.Player1.Dash.started += P1Dash => StartDash();
        // input.Player1.Dash.canceled += P1Dash => EndDash();
    }

    // void StartDash()
    // {
    //     dashSpeedCTX = dashSpeed;
    // }

    // void EndDash()
    // {
    //     dashSpeedCTX = 1;
    // }

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
    // void Move2(Vector2 dir)
    // {
    //     player2.GetComponent<Rigidbody2D>().position += dir * speed * Time.deltaTime * dashSpeedCTX;
    // }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        // EndDash();
    }
}
