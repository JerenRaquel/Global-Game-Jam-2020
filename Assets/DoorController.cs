using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    private bool checkE;
    public float progress;
    public float maxProgress = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(progress <= maxProgress){
            // fillController.SetFill(progress);
            if(checkE){
                progress += 0.5f;// * Time.deltaTime;
            }
        }
        else if(progress > maxProgress){
            boxCollider2D.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pC = other.GetComponent<PlayerController>();
        if(other.CompareTag("Player")){
            checkE = true;
            if(pC.hasKey){
                progress = 100;
                pC.hasKey = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player"))
            checkE = false;
    }
}
