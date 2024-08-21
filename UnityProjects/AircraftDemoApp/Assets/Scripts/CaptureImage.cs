using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureImage : MonoBehaviour
{

    WebCamTexture webcam;

    // Start is called before the first frame update
    void Start()
    {
       webcam = new WebCamTexture();
       webcam.Play();
       Debug.LogFormat("webcam: {0} {1} x {2}", webcam.deviceName, webcam.width, webcam.height);
    }
    public Texture2D TakePhoto()
    {
        Debug.Log("Take Photo");

        Texture2D webcamImage = new Texture2D(webcam.width, webcam.height);
        webcamImage.SetPixels(webcam.GetPixels());
        webcamImage.Apply();

        return webcamImage;
    }

    public void TakePhotoToPreview(Renderer preview)
    {
        Texture2D image = TakePhoto();
        preview.material.mainTexture = image;
        
        //update the aspect ratio to match the camera
        float aspectRatio = (float)image.width / (float)image.height;
        Vector3 scale = preview.transform.localScale;
        scale.x = scale.y * aspectRatio;
        preview.transform.localScale = scale;
    }

    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
