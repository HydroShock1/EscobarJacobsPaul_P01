using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KillVolume : MonoBehaviour
{
    private BallThrower ballThrower;

    void Start()
    {

        // Find the BallThrower script attached to the GameObject with the BallThrower script
        ballThrower = FindObjectOfType<BallThrower>();
        if (ballThrower == null)
        {
            Debug.LogError("BallThrower script not found.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the ResetBall() method from the BallThrower script
            ballThrower.ResetBall();
            Debug.Log("Dead");
        }
    }
}
