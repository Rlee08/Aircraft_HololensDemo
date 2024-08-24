using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set;}
    public string ipAddress;
    private GameObject stateManager;
    public string ipaConfirmation;
    public TextMeshProUGUI ipaDisplay;
    public TMP_InputField IPinputField;
    // public string savedIPAddress;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    //Makes the data saveable by Unity
    [System.Serializable]
    class SaveData
    {
        public string ipAddress;
    }

    //When Save button is clicked, saves the input text as ipAddress and calls WriteData method to store it in file
    public void SaveIPAddress()
    {
        DataManager.Instance.ipAddress = IPinputField.text;
        Debug.Log("saved IP Address is: " + ipAddress);
        DataManager.Instance.WriteData();
    }    

    //Writes the new IP address input to json file
    public void WriteData()
    {
        SaveData data = new SaveData();
        data.ipAddress = ipAddress;
        Debug.Log("written IP Address is: " + ipAddress);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/saveip.json", json);
        Debug.Log("the json file is found in: " + Application.dataPath + "/saveip.json");
    }

    //When called, loads the saved json file IP address to be used in the session (if it exists) and then sets the correct UI
    public void LoadData()
    {
        stateManager = GameObject.FindWithTag("StateManager");
        
        string path = Application.dataPath + "/saveip.json";

        if(File.Exists(path))
        {
            //Read the string as json data structure and assign the string to ipAdress
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json); 
            ipAddress = data.ipAddress;
        
            //sets the TMPro display to state the saved IP address
            ipaConfirmation = "Your saved IP Address is " + ipAddress + " .";
            ipaDisplay.text = ipaConfirmation;

            stateManager.GetComponent<UIStateManager>().OpenConfirmation();
        }
        else
        {
            stateManager.GetComponent<UIStateManager>().OpenSetIP();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
