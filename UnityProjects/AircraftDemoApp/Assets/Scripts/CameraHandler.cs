using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    WebCamTexture webcam;
    public Texture2D image;
    [SerializeField] private GameObject cameraScreen;
    
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

        // StartCamera();
        // Debug.Log("CameraStarted");

        Texture2D webcamImage = new Texture2D(webcam.width, webcam.height);
        webcamImage.SetPixels32(webcam.GetPixels32());
        webcamImage.Apply();
        return webcamImage;
    }

    public void TakePhotoToPreview(Renderer preview)
    {
        image = TakePhoto();
        preview.material.mainTexture = image;
        
        //update the aspect ratio to match the camera
        float aspectRatio = (float)image.width / (float)image.height;
        Vector3 scale = preview.transform.localScale;
        scale.x = scale.y * aspectRatio;
        preview.transform.localScale = scale;
    }

    public void StopCamera()
    {
        webcam.Stop();
        cameraScreen.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
