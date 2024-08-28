using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManagerCaller : MonoBehaviour
{
    private GameObject chatManager;
    private MessagingController messagingController;
    public static string thisDictationResult;

    public void GetDictationResult(string result)
    {
        thisDictationResult = result;
    }
    // public void CallOutputDictationResult()
    // {
    //     chatManager = GameObject.FindWithTag("MessagingController");
    //     messagingController = chatManager.GetComponent<MessagingController>();
        
    //     messagingController.OutputDictationResult(thisDictationResult);
    // }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
