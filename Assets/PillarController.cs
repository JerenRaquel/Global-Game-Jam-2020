using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    public float health;
    SpriteRenderer sR;
    bool ePressed;
    bool checkE;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0){
            health -= 10 * Time.deltaTime;
            if(checkE && health < 100){
                health += 20 * Time.deltaTime;
            }
       }
       else if(health <= 0){
            sR = GetComponent<SpriteRenderer>();
            sR.color = Color.blue;
        }
        //Debug.Log("health: " + health);


    }

    void OnTriggerEnter2D(Collider2D other)
   {
       checkE = true;
   }

   void OnTriggerExit2D(Collider2D other){
       checkE = false;
   }
}
