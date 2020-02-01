using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void OnEnable()
    {
        FloorGenerator.NewFloor += CreatedNewFloor;
    }

    void OnDisable()
    {
        FloorGenerator.NewFloor -= CreatedNewFloor;
    }

    void CreatedNewFloor()
    {
        FloorGenerator.instance.Generate(Random.Range(0, FloorGenerator.instance.toBeConvertedLevel.Length));
    }
}
