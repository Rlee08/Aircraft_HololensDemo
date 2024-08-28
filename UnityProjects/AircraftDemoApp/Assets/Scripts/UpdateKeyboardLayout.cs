using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateKeyboardLayout : MonoBehaviour
{
    [SerializeField] GameObject sendButton;
    void OnEnable()
    {
        StartCoroutine(UpdateLayoutGroup(sendButton));
    }

    IEnumerator UpdateLayoutGroup(GameObject prefabInstance)
    {
        yield return new WaitForSeconds(0.5f);
        prefabInstance.SetActive(false);
        prefabInstance.SetActive(true);
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
