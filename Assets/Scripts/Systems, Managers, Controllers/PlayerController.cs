using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    [Header("Players")]
    public GameObject player1;

    [Header("Settings")]
    public float speed;
    public float dashSpeed;

    public InputMaster input;
    private float dashSpeedCTX = 1;

    void Awake()
    {
        input = new InputMaster();
        input.Player1.Movement.performed += P1Movement => Move(P1Movement.ReadValue<Vector2>());
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

    void Move(Vector2 dir)
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
        // EndDash();
    }
}
