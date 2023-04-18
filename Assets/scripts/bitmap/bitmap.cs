using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bitmap : MonoBehaviour
{
    public GameObject wallObject;
    public TextAsset imageAsset;
    public float scale = 1f;

    public void Start()
    {
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
                    Instantiate(wallObject, new Vector3(x, 5, z), Quaternion.identity, this.transform);
                }
            }
        }

        MeshFilter[] filter = GetComponentsInChildren<MeshFilter>();

        Mesh final = new Mesh();
        final.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        CombineInstance[] combine = new CombineInstance[filter.Length];

        for (int i = 1; i <filter.Length; i++){
            combine[i].subMeshIndex = 0;
            combine[i].mesh = filter[i].sharedMesh;
            combine[i].transform = filter[i].transform.localToWorldMatrix;

        }

        final.CombineMeshes(combine);

        GetComponent<MeshFilter>().sharedMesh = final;

        for (int i = 0; i < transform.childCount; i++){
            Destroy(transform.GetChild(i).gameObject);

        }        
    }

    public void Update(){
        GameObject walls = GameObject.Find("wall-generator");

        walls.transform.localScale = new Vector3(scale, scale, scale);
    }
}
