using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MixedReality.Toolkit.UX.Experimental;
// using UnityEditor.Overlays;


public class KeyboardManager : MonoBehaviour

{
    [SerializeField] private GameObject firstKeyboard;
    [SerializeField] GameObject secondKeyboard;
    [SerializeField] TextMeshProUGUI keyboardText;

    
    public void KillFirstKeyboard()
    {
        Destroy(firstKeyboard);
    }

    public void PresentSecondKeyboard()
    {        
        secondKeyboard.GetComponent<NonNativeKeyboard>().Open(NonNativeKeyboard.LayoutType.Alpha);
    }

    public void ClearSecondKeyboard()
    {
        keyboardText.text = null;        
    }

    public void CloseSecondKeyboard()
    {
        // secondKeyboard.GetComponent<NonNativeKeyboard>().Clear();
        keyboardText.text = null;
        secondKeyboard.GetComponent<NonNativeKeyboard>().Close();
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
