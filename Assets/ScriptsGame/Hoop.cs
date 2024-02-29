using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    private BallThrower ballThrower;

    public float moveSpeed = 2f; // Speed of the movement
    public float moveDistance = 2f; // Distance the hoop moves from its original position

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the hoop
        initialPosition = transform.position;

        // Find the BallThrower script attached to the GameObject with the BallThrower script
        ballThrower = FindObjectOfType<BallThrower>();
        if (ballThrower == null)
        {
            Debug.LogError("BallThrower script not found.");
        }
    }
    void Update()
    {
        // Calculate the horizontal movement using Mathf.Sin to create a smooth oscillating motion
        float horizontalMovement = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // Update the position of the hoop
        transform.position = initialPosition + new Vector3(horizontalMovement, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the ResetBall() method from the BallThrower script
            ballThrower.ResetBall();
            Debug.Log("SCORE");
        }
    }
}

