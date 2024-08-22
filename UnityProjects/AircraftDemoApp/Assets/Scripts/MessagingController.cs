using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MessagingController : MonoBehaviour
{
    public static string dictationResult;

    public void DictationResult(string text)
    {
        dictationResult = text;
        Debug.Log(dictationResult);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
