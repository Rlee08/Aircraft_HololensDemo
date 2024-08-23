using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IPInputManager : MonoBehaviour
{
    public TMP_InputField IPinputField;
    public string savedIPAddress;
    
    //When user is done editing text input, gets the string and sets to savedIPAddress
    // public void GetIPAddress(string s)
    // {
    //     s = savedIPAddress;
    //     Debug.Log("saved IP Address is: " + savedIPAddress);
    // }

    // On Save button pressed, saves the savedIPAddress string to the DataManager
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
