using MixedReality.Toolkit.Examples.Demos;
using System;
using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;

// using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MessagingController : MonoBehaviour
{
    // public static string dictationResult;
    public GameObject messageRightPrefab;
    public GameObject messageLeftPrefab;
    [SerializeField] GameObject messagesContainer;
    public int userMessageCount;
    public int ragResponseCount;
    private GameObject messageRightClone;
    private GameObject currentMessageRightClone;
    private GameObject messageLeftClone;
    private GameObject currentMessageLeftClone;
    public static string ragText;

    
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
        ragText = "This is the text that will be received from RAG";        
        
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

    // Gets the dictation result into a string
    // public void OutputDictationResult(string text)
    // {
    //     dictationResult = text;
    //     Debug.Log(dictationResult);
    // }


    // Start is called before the first frame update
    void Start()
    {
        userMessageCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
