using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RAGConnector : MonoBehaviour
{
    public static string dictationResult;


    // Gets the dictation result into a string
    public void OutputDictationResult(string text)
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
