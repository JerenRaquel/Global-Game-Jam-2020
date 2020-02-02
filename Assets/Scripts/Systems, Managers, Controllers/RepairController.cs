using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{

    public FillController fillController;
    public float rate;
    private float ogRate;

    public bool repairActive = false;
    public static RepairController instance = null;

    void Start(){
        instance = this;
        rate = 2;
        ogRate = rate;
    }

    void FixedUpdate(){

    }

    public void StartPowerUpTime()
    {
        rate *= 1.15f;
        StartCoroutine(PowerUpTime());
    }

    IEnumerator PowerUpTime()
    {
        yield return new WaitForSeconds(5f);

        rate = ogRate;
    }

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

    #region Calls Repair through events
    void OnEnable()
    {
        PlayerController.Interacting += Repair;
    }

    void OnDisable()
    {
        PlayerController.Interacting -= Repair;
    }
    #endregion

    //checks to see if the fillcontroller is done (ie 1) and stops the player from interacting with it
    void Repair()
    {
        if(fillController.isDone)
        {
            GameController.instance.CreatedNewFloor(); 
            return;
        }
        //increase the fill gauge as long as the player is repairing it
        if(repairActive && !fillController.isDone)
            fillController.IncreaseFill(rate);
    }
}
