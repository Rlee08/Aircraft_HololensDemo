using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public WebCamTexture webcam;
    
    // Start is called before the first frame update
    void Start()
    {
        webcam = new WebCamTexture();
        webcam.Play();
        Debug.LogFormat("webcam: {0} {1} x {2}", webcam.deviceName, webcam.width, webcam.height);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
