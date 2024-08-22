using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MessagingController : MonoBehaviour
{
    public static string dictationResult;
    public GameObject messageRightPrefab;
    [SerializeField] GameObject messagesContainer;
    public int userMessageCount;
    private GameObject messageRightClone;

    // Makes a new speech bubble for every new recording
    public void MakeNewMessage()
    {
        userMessageCount ++ ;
        messageRightClone = Instantiate(messageRightPrefab);
        messageRightClone.transform.SetParent(messagesContainer.transform, false);
        // messageRightClone.transform.position = new Vector3(0,0,0);
        // messageRightClone.transform.localScale = new Vector3(1,1,1);
        messageRightClone.name = "MessageRight" + userMessageCount;
        StartCoroutine(UpdateLayoutGroup(messageRightClone));
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
