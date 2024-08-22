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
    public static string dictationResult;
    public GameObject messageRightPrefab;
    [SerializeField] GameObject messagesContainer;
    [SerializeField] GameObject recordButton;
    [SerializeField] GameObject listeningButton;
    public int userMessageCount;
    private GameObject messageRightClone;
    private GameObject currentMessageRightClone;

    
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

    // Forces the layout group to update to fix the formatting
    IEnumerator UpdateLayoutGroup(GameObject prefabInstance)
    {
        yield return new WaitForEndOfFrame();
        prefabInstance.SetActive(false);
        prefabInstance.SetActive(true);
    }

    // Gets the dictation result into a string
    public void OutputDictationResult(string text)
    {
        dictationResult = text;
        Debug.Log(dictationResult);
    }


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
