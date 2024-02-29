using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    private GameObject Ball;

    float startTime, endTime, swipeDistance, swipeTime;
    private Vector2 startPos;
    private Vector2 endPos;

    public float MinSwipDist = 0;
    private float BallVelocity = 0;
    private float BallSpeed = 0;
    public float MaxBallSpeed = 350;
    private Vector3 angle;

    private bool thrown, holding;
    private Vector3 newPosition;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        setupBall();
    }

    void setupBall()
    {
        GameObject _ball = GameObject.FindGameObjectWithTag("Player");
        Ball = _ball;
        rb = Ball.GetComponent<Rigidbody>();
        ResetBall();
    }

    public void ResetBall()
    {
        angle = Vector3.zero;
        endPos = Vector2.zero;
        startPos = Vector2.zero;
        BallSpeed = 0;
        startTime = 0;
        endTime = 0;
        swipeDistance = 0;
        swipeTime = 0;
        thrown = holding = false;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        Ball.transform.position = transform.position;
    }

    void PickupBall()
    {
        // Touch input handling for moving the ball
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = touch.position;
            touchPosition.z = Camera.main.nearClipPlane * 5f;
            newPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            Ball.transform.localPosition = Vector3.Lerp(Ball.transform.localPosition, newPosition, 80f * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (holding)
            PickupBall();

        if (thrown)
            return;

        // Touch input detection for throwing the ball
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit _hit;

                if (Physics.Raycast(ray, out _hit, 100f))
                {
                    if (_hit.transform == Ball.transform)
                    {
                        startTime = Time.time;
                        startPos = touch.position;
                        holding = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < 0.5f && swipeDistance > 30f)
                {
                    //throw ball
                    CalSpeed();
                    CalAngle();
                    rb.AddForce(new Vector3((angle.x * BallSpeed), (angle.y * BallSpeed / 3), (angle.z * BallSpeed) * 2));
                    rb.useGravity = true;
                    holding = false;
                    thrown = true;
                }
                else
                    ResetBall();
            }
        }
    }

    private void CalAngle()
    {
        angle = Camera.main.ScreenToWorldPoint(new Vector3(endPos.x, endPos.y + 50f, (Camera.main.nearClipPlane + 5)));
    }

    void CalSpeed()
    {
        if (swipeTime > 0)
            BallVelocity = swipeDistance / (swipeDistance - swipeTime);

        BallSpeed = BallVelocity * -40;

        if (BallSpeed <= MaxBallSpeed)
        {
            BallSpeed = MaxBallSpeed;
        }
        swipeTime = 0;
    }
}
