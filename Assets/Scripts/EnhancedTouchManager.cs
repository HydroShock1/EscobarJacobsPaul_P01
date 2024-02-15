using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class EnhancedTouchManager : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    private void Start()
    {
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {

    }

    private void Update()
    {
        foreach (EnhancedTouch.Touch touch in EnhancedTouch.Touch.activeTouches)
        {
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {

            }
        }
    }
}
