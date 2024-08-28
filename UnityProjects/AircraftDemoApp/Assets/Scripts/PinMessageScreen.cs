using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMessageScreen : MonoBehaviour
{
    public void DisableRadialView()
    {
        GetComponent<RadialView>().enabled = false;
    }

    public void EnableRadialView()
    {
        GetComponent<RadialView>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
