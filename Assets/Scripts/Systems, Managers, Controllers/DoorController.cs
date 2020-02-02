using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    private bool checkE;
    public float progress;
    public float maxProgress = 100;
    public PlayerController pC;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        pC = PlayerController.instance;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        pC = PlayerController.instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(progress <= maxProgress){
            // fillController.SetFill(progress);
            if(checkE){
                spriteRenderer.color = Color.gray;
                progress += 1f;// * Time.deltaTime;
            }
            else{
                spriteRenderer.color = Color.white;
            }
        }
        else if(progress > maxProgress){
            spriteRenderer.color = Color.gray;
            boxCollider2D.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            checkE = true;
            if(pC != null && pC.hasKey && progress < maxProgress){
                progress = maxProgress;
                pC.hasKey = false;
                Debug.Log("Key used");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player"))
            checkE = false;
    }
}
