using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    static WebCamTexture cam;

    void Start()
    {
        if (cam == null)
            cam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = cam;

        if (!cam.isPlaying)
            cam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
