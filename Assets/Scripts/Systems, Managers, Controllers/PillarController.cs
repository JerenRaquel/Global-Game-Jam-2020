﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    public float health;
    SpriteRenderer sR;
    bool ePressed;
    bool checkE;
    float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = 250;
        maxHealth = health;
        sR = GetComponent<SpriteRenderer>();
    }

    void SetColor()
    {
        if(health >= maxHealth)
            sR.color = Color.white;
        else if(health > (maxHealth * .75))
            sR.color = Color.blue;
        else if(health > (maxHealth * .50))
            sR.color = Color.green;
        else if(health > (maxHealth * .25))
            sR.color =  Color.yellow;
        else if(health > (maxHealth * .1))
            sR.color = Color.red;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health > 0){
            // fillController.SetFill(health);
            SetColor();
            if(checkE && health < maxHealth){
                health += 10;// * Time.deltaTime;
            }
            else
                health -= 15 * Time.deltaTime;
        }
        else if(health <= 0){
            sR.color = Color.black;
        }
        //Debug.Log("health: " + health);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            checkE = true;
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player"))
            checkE = false;
    }
}
