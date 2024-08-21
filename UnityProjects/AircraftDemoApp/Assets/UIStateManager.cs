using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateManager : MonoBehaviour
{
    private GameObject mainMessageScreen;
    private GameObject cameraScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        mainMessageScreen = GameObject.Find("MainPanelHolster");
        cameraScreen = GameObject.Find("CameraButtonCanvas");

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
