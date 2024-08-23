using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IPInputManager : MonoBehaviour
{
    public TMP_InputField IPinputField;
    public string savedIPAddress;
    

    public void SaveIPAddress()
    {
        savedIPAddress = IPinputField.text;
        Debug.Log("saved IP Address is: " + savedIPAddress);
        
        DataManager.Instance.ipAddress = savedIPAddress;
        DataManager.Instance.WriteData();
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
