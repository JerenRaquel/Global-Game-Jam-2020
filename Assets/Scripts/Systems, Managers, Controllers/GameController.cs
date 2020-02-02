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
        FloorGenerator.instance.Generate(1);//Random.Range(0, FloorGenerator.instance.toBeConvertedLevel.Length));
    }
}
