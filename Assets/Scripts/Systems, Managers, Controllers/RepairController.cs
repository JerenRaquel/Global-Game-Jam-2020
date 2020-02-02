using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{
    public FillController fillController;
    public float rate;
    private float ogRate;
    private bool powerUp = false;

    public bool repairActive = false;

    void Start(){
        ogRate = rate;
    }

    void FixedUpdate(){
        if(rate != ogRate && !powerUp){
                StartCoroutine(PowerUpTime());
                powerUp =  true;
        }
        else if(rate == ogRate){
            powerUp = false;
        }
    }

    //this is needed for some weird reason?
    public void StartPowerUpTime()
    {
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
