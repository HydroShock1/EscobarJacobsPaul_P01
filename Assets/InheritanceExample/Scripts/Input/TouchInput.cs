using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TouchInput : MonoBehaviour
{
    public static event Action Clicked;
    
    public Vector2 TouchScreenPosition { get; private set; }
    public bool TouchIsHeld { get; private set; }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            TouchIsHeld = true;
            // update touch location
            Touch touch = Input.GetTouch(0);
            // detect if this touch just happened
            Debug.Log("STATE: 2");
            if (touch.phase == TouchPhase.Began)
            {
                Clicked?.Invoke();
            }
            //update location
            TouchScreenPosition = touch.position;
        }
        else
        {
            TouchIsHeld = false;
        }
    }
}
