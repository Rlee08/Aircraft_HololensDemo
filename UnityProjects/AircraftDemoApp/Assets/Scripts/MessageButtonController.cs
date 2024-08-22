using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageButtonController : MonoBehaviour
{
    // private GameObject buttonCanvas;
    private GameObject uiStateManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        uiStateManager = GameObject.FindWithTag("StateManager");
    }

    public void UISMSwitchToDefault()
    {
        uiStateManager.GetComponent<UIStateManager>().SwitchToDefault();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
