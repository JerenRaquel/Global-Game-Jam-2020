using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    public float health;
    SpriteRenderer sR;
    bool ePressed;
    bool checkE;
    float maxHealth;
    bool shooked = false;
    private float decayRate = 14;

    // Start is called before the first frame update
    void Start()
    {
        health = 250;
        maxHealth = health;
        sR = GetComponent<SpriteRenderer>();
        StartCoroutine(startDeath());
    }

    void Shake()
    {
        shooked = true;
        GameController.instance.Shake();
    }

    void SetColor()
    {
        if(health >= (maxHealth * 0.75))
        {
            sR.color = Color.white;
            shooked = false;
        }
        else if(health > (maxHealth * .65))
        {
            sR.color = Color.blue;
            shooked = false;
        }
        else if(health > (maxHealth * .45))
        {
            sR.color = Color.green;
            shooked = false;
        }
        else if(health > (maxHealth * .25))
        {
            sR.color =  Color.yellow;
            shooked = false;
        }
        else if(health > (maxHealth * .1))
        {
            sR.color = Color.red;
            if(!shooked)
                Shake();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health > 0){
            // fillController.SetFill(health);
            SetColor();
            if(checkE && health < maxHealth){
                health += 150 * Time.deltaTime;
            }
            else
                health -= decayRate * Time.deltaTime;
        }
        else if(health <= 0){
            sR.color = Color.black;
            GameController.instance.EndGame();
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

    IEnumerator startDeath(){
        yield return new WaitForSeconds(120);
        decayRate *= 3;
    }
}
