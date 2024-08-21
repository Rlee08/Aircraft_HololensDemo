using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixedReality.Toolkit.UX
{
    public class ToggleRotate : MonoBehaviour
    {
        [SerializeField]
        private GameObject arrow;

        [SerializeField]
        private StatefulInteractable statefulInteractable;

        // Start is called before the first frame update
        void Start()
        {
            // If the StatefulInteractable is null, 
            if (statefulInteractable == null)
            {
                statefulInteractable = GetComponent<StatefulInteractable>();
            }
            
            bool isToggled = statefulInteractable.IsToggled;

            if (isToggled)
            {
                arrow.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            }
            else
            {
                arrow.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }

            lastToggleState = isToggled;
        }
        private bool lastToggleState;

        // Update is called once per frame
        void Update()
        {
            bool isToggled = statefulInteractable.IsToggled;            
            
            if (lastToggleState != isToggled)
            {
                lastToggleState = isToggled;
            }

            if (isToggled)
            {
                arrow.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            }
            else
            {
                arrow.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }

            lastToggleState = isToggled;
        }
    }
}