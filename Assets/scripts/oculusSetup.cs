using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oculusSetup : MonoBehaviour
{
    public float opacity = 0;
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
            Debug.Log("android");

            RenderSettings.skybox = null;

            var mrp = GameObject.Find("MixedRealityPlayspace");

            var passthoughLayer = mrp.AddComponent<OVRPassthroughLayer>();
            var manager = mrp.AddComponent<OVRManager>();

            manager.isInsightPassthroughEnabled = true;
            passthoughLayer.textureOpacity = opacity;
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
