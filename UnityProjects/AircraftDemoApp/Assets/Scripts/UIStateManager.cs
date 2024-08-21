using MixedReality.Toolkit.Examples.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        mainMessageScreen = GameObject.Find("MainPanelHolster");
        cameraScreen = GameObject.Find("CameraButtonCanvas");
        expandButtons = GameObject.Find("AddButtons");
        transcriptionDialogue = GameObject.Find("TranscriptionDialogue"); 
        
        expandButtons.SetActive(false);
        transcriptionDialogue.SetActive(false);
        mainMessageScreen.SetActive(false);
        cameraScreen.SetActive(false);
    }

    public void assessDamage()
    {

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
        // if (transcriberDictationHandler.dictationSubsystem != null)
        // {
        //     dictationSubsystem.StopDictation();
        // }
    }
}
