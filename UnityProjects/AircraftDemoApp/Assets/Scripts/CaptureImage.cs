using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureImage : MonoBehaviour
{
    WebCamTexture webcam;
    private Renderer chatPreview;
    private GameObject assessDamageMessageClone;
    [SerializeField] private GameObject assessDamageMessagePrefab;
    [SerializeField] private GameObject messagesContainer;
    private GameObject messagePhotoPreview;
    public VoiceCommandManager voiceCommandManager;
    [SerializeField] private GameObject autoCameraScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartCamera()
    {
        webcam = new WebCamTexture();
        webcam.Play();
        // Debug.LogFormat("webcam: {0} {1} x {2}", webcam.deviceName, webcam.width, webcam.height);        
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

    public void StopCamera()
    {
        webcam.Stop();
    }

    // public void TakePhotoToPreview(Renderer preview)
    // {
    //     Texture2D image = TakePhoto();
    //     preview.material.mainTexture = image;
        
    //     //update the aspect ratio to match the camera
    //     float aspectRatio = (float)image.width / (float)image.height;
    //     Vector3 scale = preview.transform.localScale;
    //     scale.x = scale.y * aspectRatio;
    //     preview.transform.localScale = scale;

    //     Invoke("StopCamera", 8);
    // }

    public void MakePhotoPreviewMessage()
    {
        //Instantiates the assess damage message clone
        assessDamageMessageClone = Instantiate(assessDamageMessagePrefab);
        assessDamageMessageClone.transform.SetParent(messagesContainer.transform, false);        

        //Gets the renderer component for the messagePhotoPreview
        messagePhotoPreview = GameObject.FindWithTag("MessagePhotoPreview");
        chatPreview = messagePhotoPreview.GetComponent<Renderer>();
        
        //Sets the messagePhotoPreview Renderer to be the photo
        Texture2D image = TakePhoto();
        chatPreview.material.mainTexture = image;

        //update the aspect ratio to match the camera
        float aspectRatio = (float)image.width / (float)image.height;
        Vector3 scale = chatPreview.transform.localScale;
        scale.x = scale.y * aspectRatio;
        chatPreview.transform.localScale = scale;

        //Calls force update script
        StartCoroutine(UpdateLayoutGroup(assessDamageMessageClone));       
    }
    
    // Forces the layout group to update to fix the formatting
    IEnumerator UpdateLayoutGroup(GameObject prefabInstance)
    {
        yield return new WaitForEndOfFrame();
        prefabInstance.SetActive(false);
        prefabInstance.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
