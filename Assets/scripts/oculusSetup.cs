using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oculusSetup : MonoBehaviour
{
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
            passthoughLayer.textureOpacity = 0.3f;
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
