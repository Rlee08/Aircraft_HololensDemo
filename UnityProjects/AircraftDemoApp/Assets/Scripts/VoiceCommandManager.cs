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

    [SerializeField] private GameObject addButtons;

    [SerializeField] private GameObject mainMessenger;
    [SerializeField] private GameObject handMenu;
    [SerializeField] MessagingController messagingController;
    public bool isListening = false;

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
        StartCoroutine (StopListening());
        // transcriberDictationHandler.StartRecognition();
        // transcriptionDialogue.SetActive(true);
    }

    private IEnumerator StopListening()
    {
        if (isListening == true)
        {
            yield return new WaitForSeconds(20);
            isListening = false;
            Debug.Log("listening stopped");
        }
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

    public void expandMenu()
    {
        if (isListening == true)
        {
            Debug.Log("Keyword Detected: expand hand menu");
            addButtons.SetActive(true);
        }
    }

    public void openMainMessenger()
    {
        if (isListening == true)
        {
            Debug.Log("Wingman active, opening messaging screen");
            mainMessenger.SetActive(true);
            handMenu.SetActive(false);
        }
    }

    public void RetrieveFigure()
    {
        Debug.Log("Retrieve figure");
        messagingController.MakeFigureResponse();
    }

}
