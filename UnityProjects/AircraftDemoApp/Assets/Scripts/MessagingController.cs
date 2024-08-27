using MixedReality.Toolkit.Examples.Demos;
using System;
using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;

// using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.ComponentModel;
// using UnityEditor.Search;

public class MessagingController : MonoBehaviour
{
    Thread clientThread;
    TcpClient client;
    NetworkStream stream;
    bool isRunning = true;
    private string setIPAddress;
    private int setPort;

    public GameObject messageRightPrefab;
    public GameObject messageLeftPrefab;
    [SerializeField] GameObject messagesContainer;
    public int userMessageCount;
    public int ragResponseCount;
    private GameObject messageRightClone;
    private GameObject currentMessageRightClone;
    private GameObject messageLeftClone;
    private GameObject currentMessageLeftClone;
    public string ragText;
    private bool newResponse = false;
    private Texture2D messageImage;
    public static string dictationResult;
    private GameObject figureMessageClone;
    public GameObject figureMessagePrefab;
    private Renderer chatPreview;
    private GameObject assessDamageMessageClone;
    [SerializeField] private GameObject assessDamageMessagePrefab;
    private GameObject messagePhotoPreview;
    [SerializeField] CameraHandler cameraHandler;
    
    // Instantiates a new speech bubble for every new recording
    public void MakeNewMessage()
    {
        userMessageCount ++ ;
        messageRightClone = Instantiate(messageRightPrefab);
        messageRightClone.transform.SetParent(messagesContainer.transform, false);
        messageRightClone.name = "MessageRight" + userMessageCount;
        StartCoroutine(UpdateLayoutGroup(messageRightClone));
    }

    // Calls DictationHandler and starts recognition for this unique Instantiate
    public void RecordNewMessage()
    {
        currentMessageRightClone = GameObject.Find("MessageRight" + userMessageCount);
        // Debug.Log("found " + currentMessageRightClone);

        currentMessageRightClone.GetComponent<DictationHandler>().StartRecognition();
        // Debug.Log("recognition should start for " + currentMessageRightClone);
    }

    // Stops recognition and returns to listening button back to normal record button
    public void StopRecording()
    {
        currentMessageRightClone = GameObject.Find("MessageRight" + userMessageCount);
        currentMessageRightClone.GetComponent<DictationHandler>().StopRecognition();
    }

    // Gets the dictation result into a string and then sends to server
    public void OutputDictationResult(string text)
    {   
        dictationResult = text;
        Debug.Log(dictationResult);

        // Sends the dictation result to server
        if (stream != null && client.Connected)
        {
            byte[] message = Encoding.UTF8.GetBytes(dictationResult);
            stream.Write(message, 0, message.Length);
            Debug.Log("Sent input to server: " + dictationResult);
        }
    }

    // Instantiates a new speech bubble for every new RAG response
    public void MakeNewResponse()
    {        
        // using this string to test to send to the speech bubble
        // ragText = "This is the text that will be received from RAG";
        
        //Creates the speech bubble
        ragResponseCount ++ ;
        messageLeftClone = Instantiate(messageLeftPrefab);
        messageLeftClone.transform.SetParent(messagesContainer.transform, false);
        messageLeftClone.name = "MessageLeft" + ragResponseCount;
        StartCoroutine(UpdateLayoutGroup(messageLeftClone));

        //Calls RAGDisplayer to populate the speech bubble with string
        currentMessageLeftClone = GameObject.Find("MessageLeft" + ragResponseCount);
        currentMessageLeftClone.GetComponent<RAGDisplayer>().DisplayRAGMessage(ragText);
    }

    public void MakeFigureResponse()
    {
        figureMessageClone = Instantiate(figureMessagePrefab);
        figureMessageClone.transform.SetParent(messagesContainer.transform, false);
        StartCoroutine(UpdateLayoutGroup(figureMessageClone));
    }

    public void MakePhotoPreviewMessage()
    {
        //Instantiates the assess damage message clone
        assessDamageMessageClone = Instantiate(assessDamageMessagePrefab);
        assessDamageMessageClone.transform.SetParent(messagesContainer.transform, false);        

        //Gets the renderer component for the messagePhotoPreview
        messagePhotoPreview = GameObject.FindWithTag("MessagePhotoPreview");
        chatPreview = messagePhotoPreview.GetComponent<Renderer>();
        
        //Sets the messagePhotoPreview Renderer to be the photo
        messageImage = cameraHandler.image;
        chatPreview.material.mainTexture = messageImage;

        //update the aspect ratio to match the camera
        float aspectRatio = (float)messageImage.width / (float)messageImage.height;
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

    // Start is called before the first frame update
    void Start()
    {
        userMessageCount = 0;
        ragResponseCount = 0;
        clientThread = new Thread(new ThreadStart(StartClient));
        clientThread.Start();
    }

    void StartClient()
    {
        try
        {
            setIPAddress = DataManager.Instance.ipAddress;
            Debug.Log(setIPAddress);
            
            setPort = int.Parse(DataManager.Instance.port);
            Debug.Log(setPort);

            client = new TcpClient(setIPAddress, setPort);
            stream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (isRunning)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Debug.Log("Received response: " + response);

                    ragText = response;
                    Debug.Log("response is" + ragText);
                    // MakeNewResponse();
                    newResponse = true;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Exception: " + e.Message);
        }
        finally
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Debug.Log("Client closed.");
        }
    }

    void OnApplicationQuit()
    {
        isRunning = false;
        if (clientThread != null)
        {
            clientThread.Join();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(newResponse)
        {
            MakeNewResponse();
            newResponse = false;
        }
    }
}
