using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    private BallThrower ballThrower;

    public float moveSpeed = 2f; // Speed of the movement
    public float moveDistance = 2f; // Distance the hoop moves from its original position

    private Vector3 initialPosition;


    private Timer timer;

    void Start()
    {
        // Store the initial position of the hoop
        initialPosition = transform.position;

        ballThrower = FindObjectOfType<BallThrower>();
        if (ballThrower == null)
        {
            Debug.LogError("BallThrower script not found.");
        }

        timer = FindObjectOfType<Timer>();
        if (timer == null)
        {
            Debug.LogError("Timer script not found.");
        }
    }
    void Update()
    {
        float horizontalMovement = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        transform.position = initialPosition + new Vector3(horizontalMovement, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ballThrower.ResetBall();

            timer.IncrementScore(1); 
            Debug.Log("SCORE");

            timer.CheckWinLose(); 
        }
    }
}

