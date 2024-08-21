using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.Subsystems;
using MixedReality.Toolkit.Examples.Demos;

public class VoiceCommandManager : MonoBehaviour
{
    [SerializeField] DictationHandler transcriberDictationHandler;
    [SerializeField] private GameObject transcriptionDialogue;
    [SerializeField] private GameObject autoCameraScreen;
    private bool isListening = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startListening()
    {
        Debug.Log("Keyword Detected: wingman");
        isListening = true;
        // transcriberDictationHandler.StartRecognition();
        // transcriptionDialogue.SetActive(true);
    }
    public void assessDamage()
    {
        if (isListening == true)
        {
            Debug.Log("Keyword Detected: assess damage");
            autoCameraScreen.SetActive(true);
        }
        else
        {
           Debug.Log("not listening"); 
        }
    }
}
