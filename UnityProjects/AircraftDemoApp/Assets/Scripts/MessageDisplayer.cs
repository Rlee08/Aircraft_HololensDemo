using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageDisplayer : MonoBehaviour
{
    public TextMeshProUGUI userMessage;

    public void DisplayUserMessage(string thisUserText)
    {
        //Sets the retrieved string as TextMeshPro text
        userMessage.text = thisUserText;
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
