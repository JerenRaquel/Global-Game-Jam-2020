﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemType;
    public SpriteRenderer spriteRenderer;
    public RepairController repair;

    public Sprite speedItem;
    public Sprite repairItem;
    public Sprite doorItem;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        PlayerController player = other.GetComponent<PlayerController>();
        if(itemType == 1){
            player.speed *= 1.5f;
        }
        else if(itemType == 2){
            repair.rate *= 1.15f;
        }
        else if(itemType == 3){
            player.hasKey = true;
        }
        Destroy(gameObject);
    }
}
