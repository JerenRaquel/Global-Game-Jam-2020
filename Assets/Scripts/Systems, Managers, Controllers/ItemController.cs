using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemType;
    public SpriteRenderer spriteRenderer;
    public RepairController repair;
    public GameObject floor;
    // public GameObject parent;

    public Sprite speedItem;
    public Sprite repairItem;
    public Sprite doorItem;

    // Start is called before the first frame update
    void Start()
    {
        itemType = Random.Range(1, 4);
        if(itemType == 1){
            spriteRenderer.sprite = speedItem;
        }
        else if(itemType == 2){
            spriteRenderer.sprite = repairItem;
        }
        else if(itemType == 3){
            spriteRenderer.sprite = doorItem;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        PlayerController player = PlayerController.instance;
        if(itemType == 1){
            player.speed *= 1.5f;
            PlayerController.instance.StartPowerUpTime();
        }
        else if(itemType == 2){
            repair.rate *= 1.15f;
            if(repair != null)
                repair.StartPowerUpTime();
        }
        else if(itemType == 3){
            player.hasKey = true;
        }
        Instantiate(floor, transform.position, Quaternion.identity, FloorGenerator.instance.OutputTransform);
        Destroy(gameObject); 
    }
}
