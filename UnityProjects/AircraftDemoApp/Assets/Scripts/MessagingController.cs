using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagingController : MonoBehaviour
{
    public TextMeshProUGUI dictatedMessage;
    public string textMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dictatedMessage.text = textMessage;
        Debug.Log(textMessage);
    }
}
