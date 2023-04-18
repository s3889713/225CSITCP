using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TerrainBuilder : MonoBehaviour
{
    public TextAsset imageAsset;

    

    int depth = 20;
    int height = 256;
    int width = 256;

    // Start is called before the first frame update
    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = generateTerrain(terrain.terrainData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    TerrainData generateTerrain(TerrainData terrainData){
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0,0,generateHights());

        return terrainData;
    }

    float[,] generateHights(){
        float[,] heights = new float[width, height];
        Texture2D tex = new Texture2D(2, 2);
        ImageConversion.LoadImage(tex, imageAsset.bytes);

        for(int x = 0; x < tex.width; x++){
            for(int z = 0; z < tex.height; z++){
                Color pixel = tex.GetPixel(x, z);

                Color white = Color.white;
                var r = Math.Abs(pixel.r - white.r);
                var g = Math.Abs(pixel.g - white.g);
                var b = Math.Abs(pixel.b - white.b);

                if (r + g + b > 0.5){
                    heights[x,z] = 1;
                }
                else{
                    heights[x,z] = 0;
                }
            }
        }

        return heights;
    }
}
