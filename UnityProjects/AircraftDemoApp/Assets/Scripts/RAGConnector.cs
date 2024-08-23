using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using System;
using System.Net.Sockets;
using System.Threading;

public class RAGConnector : MonoBehaviour
{
    public static string dictationResult;
    TcpClient client;
    NetworkStream stream;

    // Gets the dictation result into a string and then sends to server
    public void OutputDictationResult(string text)
    {
        client = new TcpClient("127.0.0.1", 1111);
        stream = client.GetStream();
        byte[] buffer = new byte[1024];        
        
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

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
