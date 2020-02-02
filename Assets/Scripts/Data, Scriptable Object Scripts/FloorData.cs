using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloorData", menuName = "Object Templates/FloorData", order = 0)]
public class FloorData : ScriptableObject 
{
    public bool isFloor1 = false;
    public Texture2D levelArt;
}
