using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    #region Instance
    public static FloorGenerator instance = null;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public delegate void GenFloor();
    public static event GenFloor NewFloor;

    public Transform OutputTransform;
    public FloorData[] toBeConvertedLevel;
    public ColorMappings[] colorMappings;

    [Header("Settings")]
    public Vector2 offset = new Vector2(6, 4.5f);  //spacing between tile

    // Start is called before the first frame update
    void Start()
    {
        NewFloor();
    }

    //Loops through each pixel and generates the coorisponding tile
    public void Generate(int levelIndex)
    {
        Texture2D level = toBeConvertedLevel[levelIndex].levelArt;
        for(int x = 0; x < level.width; x++)
        {
            for(int y = 0; y < level.height; y++)
            {
                GenerateTile(x, y, level);
            }
        }
    }

    //Created a tile based on the pixel color of that pixel
    void GenerateTile(int x, int y, Texture2D level)
    {
        Color color = level.GetPixel(x, y);
        Vector2 positionWithOffset = new Vector2(x - offset.x, y - offset.y);

        //if transparent break out
        if(color.a == 0)
            return;
        
        //spawn the corrisponding prefab based on the color
        foreach(ColorMappings colorMap in colorMappings)
        {
            if(colorMap.pixelColor.Equals(color))
            {
                Instantiate(colorMap.prefab, positionWithOffset, Quaternion.identity, OutputTransform);
            }
        }
    }
}

[System.Serializable]
public class ColorMappings
{
    public Color pixelColor;
    public GameObject prefab;
}