using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.Subsystems;
using MixedReality.Toolkit.Examples.Demos;

public class VoiceCommandManager : MonoBehaviour
{
    [SerializeField] DictationHandler transcriberDictationHandler;
    [SerializeField] private GameObject transcriptionDialogue;

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
        transcriberDictationHandler.StartRecognition();
        transcriptionDialogue.SetActive(true);
    }
    public void assessDamage()
    {
        Debug.Log("Keyword Detected: assess damage");
    }
}
