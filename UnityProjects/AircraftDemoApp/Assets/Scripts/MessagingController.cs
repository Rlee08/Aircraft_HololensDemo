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

public class MessagingController : MonoBehaviour
{
    Thread clientThread;
    TcpClient client;
    NetworkStream stream;
    bool isRunning = true;
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
            // client = new TcpClient("10.246.138.157", 1111);
            client = new TcpClient("10.246.138.157", 1111);
            stream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (isRunning)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Debug.Log("Received command: " + response);

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
