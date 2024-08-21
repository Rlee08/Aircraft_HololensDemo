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

    public DictationHandler trasncriberDictationHandler;

    // public GameObject transcriptionDialogue;
    
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
    // Update is called once per frame
    void Update()
    {

    }
}
