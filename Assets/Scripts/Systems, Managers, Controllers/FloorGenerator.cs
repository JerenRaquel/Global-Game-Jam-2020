using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public Transform OutputTransform;
    public FloorData toBeConvertedLevel;
    public ColorMappings[] colorMappings;

    [Header("Settings")]
    public Vector2 offset = new Vector2(6, 4.5f);  //spacing between tile

    private Texture2D level;

    // Start is called before the first frame update
    void Start()
    {
        level = toBeConvertedLevel.levelArt;
        Generate();
    }

    //Loops through each pixel and generates the coorisponding tile
    void Generate()
    {
        for(int x = 0; x < level.width; x++)
        {
            for(int y = 0; y < level.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    //Created a tile based on the pixel color of that pixel
    void GenerateTile(int x, int y)
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