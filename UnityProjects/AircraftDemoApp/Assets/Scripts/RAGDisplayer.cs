using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;

public class RAGDisplayer : MonoBehaviour
{    
    public TextMeshProUGUI ragOutput;
    // private GameObject messagingController;


    // Takes a string and populates the RAG speech bubble
    public void DisplayRAGMessage(string thisRagText)
    {
        // Retrieves the public string from MessagingController
        // messagingController = GameObject.FindWithTag("MessagingController");
        // messagingController.GetComponent<MessagingController>();
        // thisRagText = MessagingController.ragText;

        //Sets the retrieved string as TextMeshPro text
        ragOutput.text = thisRagText;
    }

    internal void DisplayRAGMessage()
    {
        throw new NotImplementedException();
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
