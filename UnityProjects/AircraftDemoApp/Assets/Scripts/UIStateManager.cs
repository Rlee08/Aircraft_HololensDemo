using MixedReality.Toolkit.Examples.Demos;
using MixedReality.Toolkit.Subsystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIStateManager : MonoBehaviour
{
    private GameObject mainMessageScreen;
    private GameObject cameraScreen;
    private GameObject expandButtons;
    private GameObject transcriptionDialogue;

    [SerializeField] GameObject voiceButton;
    [SerializeField] GameObject listeningButton;
    [SerializeField] GameObject writeIP;
    [SerializeField] GameObject confirmIP;


    // public DictationHandler transcriberDictationHandler;

    
    public void SwitchToListening()
    {
        if (listeningButton.activeSelf)
        {
            voiceButton.SetActive(false);
            listeningButton.SetActive(true);           
        }
    }

    public void SwitchToDefault()
    {
        listeningButton.SetActive(false); 
        voiceButton.SetActive(true);       
    }

    public void OpenConfirmation()
    {
        writeIP.SetActive(false);
        confirmIP.SetActive(true);
    }
    public void OpenSetIP()
    {
        writeIP.SetActive(true);
        confirmIP.SetActive(false);
    }
    
    void Awake()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // private void closeTranscriberDialogueAction()
    // {
    //     transcriptionDialogue.SetActive(false);
    // }

    // public void closeTranscriberDialogue()
    // {
    //     Debug.Log("Recording Stopped");
    //     Invoke("closeTranscriberDialogueAction", 10);
    // }

    // Update is called once per frame
    void Update()
    {

    }
}
