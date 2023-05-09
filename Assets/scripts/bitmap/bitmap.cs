using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;

public class bitmap : MonoBehaviour
{
    public GameObject wallObject;
    public GameObject empty;
    public TextAsset imageAsset;
    public float scale = 0.01f;
    public Material floorMat;

    public void Start()
    {
        Texture2D bitmap = new Texture2D(2, 2);
        ImageConversion.LoadImage(bitmap, imageAsset.bytes);
        
        for(int x = 0; x < bitmap.width; x++){
            for(int z = 0; z < bitmap.height; z++){
                Color pixel = bitmap.GetPixel(x, z);

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

        Mesh finalFilter = new Mesh();
        finalFilter.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        CombineInstance[] combine = new CombineInstance[filter.Length];

        for (int i = 2; i <filter.Length; i++){
            combine[i].subMeshIndex = 0;
            combine[i].mesh = filter[i].sharedMesh;
            combine[i].transform = filter[i].transform.localToWorldMatrix;

        }

        finalFilter.CombineMeshes(combine);

        for (int i = 1; i < transform.childCount; i++){
            Destroy(transform.GetChild(i).gameObject);
        }

        GetComponent<MeshFilter>().sharedMesh = finalFilter;

        var inner = Instantiate(empty, new Vector3(0,0,0), Quaternion.identity, this.transform);
        int layer = LayerMask.NameToLayer("Interior");
        inner.layer = layer;
        var innerMesh = inner.AddComponent<MeshFilter>();
        inner.AddComponent<MeshRenderer>();
        innerMesh.GetComponent<MeshFilter>().sharedMesh = finalFilter;
        inner.AddComponent<MeshCollider>();

        innerMesh.GetComponent<MeshFilter>().sharedMesh = null;

        GameObject walls = GameObject.Find("wall-generator");

        walls.transform.localScale = new Vector3(0.01f,0.01f,0.01f);

        var con = walls.AddComponent<MeshCollider>();
        con.convex = true;
        System.Threading.Thread.Sleep(1000);
        walls.AddComponent<NearInteractionGrabbable>();
        walls.AddComponent<ObjectManipulator>();
        walls.AddComponent<BoundsControl>();

        var floor = GameObject.CreatePrimitive(PrimitiveType.Plane);

        floor.transform.parent = this.gameObject.transform;

        floor.transform.localScale = new Vector3(bitmap.width/10 + 2, 1f, bitmap.height/10 + 1);
        floor.transform.position = new Vector3(bitmap.width/200f, -0.5f, bitmap.height/200f);
        var floorMesh = floor.GetComponent<MeshRenderer>();
        floorMesh.material = floorMat;
        floor.layer = layer;
    }

    public void Update(){
        // GameObject walls = GameObject.Find("wall-generator");

        // walls.transform.localScale = new Vector3(scale, scale, scale);
    }
}
