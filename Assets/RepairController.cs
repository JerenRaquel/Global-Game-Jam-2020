using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{
    public FillController fillController;
    public float rate;

    public bool repairActive = false;

    #region Checking for player on repair tile
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            repairActive = true;    
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            repairActive = false;
    }
    #endregion

    void OnEnable()
    {
        PlayerController.Interacting += Repair;
    }

    void OnDisable()
    {
        PlayerController.Interacting -= Repair;
    }

    void Repair()
    {
        if(fillController.isDone)
        {
            PlayerController.interacting = false;
            return;
        }
        if(repairActive && !fillController.isDone)
            fillController.IncreaseFill(rate);
    }
}
