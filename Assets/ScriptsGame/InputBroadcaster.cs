using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsTapPressed = true;
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsTapPressed = false;
        }
    }
}
