using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Instance
    public static GameController instance = null;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public Animator animator;
    public GameObject UI;

    private int prevFloor;
    bool isDead = false;

    #region Calls CreatedNewFloor through events
    void OnEnable()
    {
        FloorGenerator.NewFloor += CreatedNewFloor;
    }

    void OnDisable()
    {
        FloorGenerator.NewFloor -= CreatedNewFloor;
    }
    #endregion

    //Creates a new random floor from the array
    public void CreatedNewFloor()
    {
        int currentFloor = Random.Range(0, FloorGenerator.instance.toBeConvertedLevel.Length);
        while(currentFloor == prevFloor)
        {
            currentFloor = Random.Range(0, FloorGenerator.instance.toBeConvertedLevel.Length);
        }
        prevFloor = currentFloor;
        FloorGenerator.instance.Generate(currentFloor);
    }

    public void Shake()
    {
        animator.SetTrigger("Shake");
    }

    void Update()
    {
        if(isDead && Input.GetKeyDown(KeyCode.F))
        {
            UI.SetActive(false);
            Time.timeScale = 1;
            isDead = false;
            SceneController.instance.LoadScene(1);
        }
    }

    public void EndGame()
    {
        UI.SetActive(true);
        Time.timeScale = 0;
        isDead = true;
    }
}
