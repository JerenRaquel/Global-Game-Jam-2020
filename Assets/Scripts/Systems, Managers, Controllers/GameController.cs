using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
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
    void CreatedNewFloor()
    {
        FloorGenerator.instance.Generate(Random.Range(0, FloorGenerator.instance.toBeConvertedLevel.Length));
    }
}
