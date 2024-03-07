using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KillVolume : MonoBehaviour
{
    private BallThrower ballThrower;

    void Start()
    {

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
            ballThrower.ResetBall();
            Debug.Log("Dead");
        }
    }
}
