using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    WebCamTexture webcam;
    public Texture2D image;
    [SerializeField] private GameObject cameraScreen;
    [SerializeField] private Renderer preview;
    [SerializeField] private GameObject previewQuad;
    [SerializeField] private GameObject confirmDialogue;
    [SerializeField] AudioSource cameraFlash;
    public Sprite Photo;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartCamera()
    {
        Debug.Log("camera started");
        webcam = new WebCamTexture();
        webcam.Play();
        Debug.Log("webcam on");
        // Debug.LogFormat("webcam: {0} {1} x {2}", webcam.deviceName, webcam.width, webcam.height);
    }
    public void TriggerPhoto()
    {
        StartCamera();
        Invoke("TakePhotoToPreview",3f);
    }
    public Texture2D TakePhoto()
    { 
        Debug.Log("Take Photo");    

        Texture2D webcamImage = new Texture2D(webcam.width, webcam.height);
        webcamImage.SetPixels32(webcam.GetPixels32());
        webcamImage.Apply();
        return webcamImage;
    }

    public void TakePhotoToPreview()
    {
        image = TakePhoto();
        preview.material.mainTexture = image;
        
        //update the aspect ratio to match the camera
        float aspectRatio = (float)image.width / (float)image.height;
        Vector3 scale = preview.transform.localScale;
        scale.x = scale.y * aspectRatio;
        preview.transform.localScale = scale;
        previewQuad.SetActive(true);
        confirmDialogue.SetActive(true);
        cameraFlash.Play();

        // webcam.Stop();
    }

    // public Sprite TakePhotoToMessage()
    // {
    //     image = TakePhoto();
    //     Sprite.Create(image, new Rect(0.0f, 0.0f, image.width, image.height), new Vector2(0.5f, 0.5f));
    //     return Photo;
    // }


    // Update is called once per frame
    void Update()
    {
        
    }
}
