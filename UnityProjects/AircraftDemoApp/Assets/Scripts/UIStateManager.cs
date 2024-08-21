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
    public DictationHandler transcriberDictationHandler;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        mainMessageScreen = GameObject.Find("MainMessagingScreen");
        cameraScreen = GameObject.Find("AutoCameraScreen");
        expandButtons = GameObject.Find("AddButtons");
        // transcriptionDialogue = GameObject.Find("TranscriptionDialogue"); 
        
        expandButtons.SetActive(false);
        // transcriptionDialogue.SetActive(false);
        mainMessageScreen.SetActive(false);
        cameraScreen.SetActive(false);
    }

    private void closeTranscriberDialogueAction()
    {
        transcriptionDialogue.SetActive(false);
    }

    public void closeTranscriberDialogue()
    {
        Debug.Log("Recording Stopped");
        Invoke("closeTranscriberDialogueAction", 10);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the first running phrase recognition subsystem.
        var keywordRecognitionSubsystem = MixedReality.Toolkit.XRSubsystemHelpers.GetFirstRunningSubsystem<KeywordRecognitionSubsystem>();

        // If we found one...
        if (keywordRecognitionSubsystem != null)
            {
            // Register a keyword and its associated action with the subsystem
            keywordRecognitionSubsystem.CreateOrGetEventForKeyword("keyword").AddListener(() => Debug.Log("Keyword recognized"));
            }
    }
}
