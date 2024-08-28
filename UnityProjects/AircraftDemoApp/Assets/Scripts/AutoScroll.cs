using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;
    public float scrollSpeed = 2;

    public IEnumerator ScrollToBottom()
    {
        while(scrollRect.verticalNormalizedPosition != 0f) {
        scrollRect.verticalNormalizedPosition = Mathf.MoveTowards(scrollRect.verticalNormalizedPosition, 0f, Time.deltaTime * scrollSpeed);
        yield return null;
        }
    }

    void OnEnable()
    {
        StartCoroutine(ScrollToBottom());
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
