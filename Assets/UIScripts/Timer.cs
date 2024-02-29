using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; // Total time for the game in seconds
    private float timeRemaining; // Time remaining for the game
    private bool gameEnded = false; // Flag to check if the game has ended
    private bool gamePaused = false; // Flag to check if the game is paused

    public Text timerText; // Reference to the UI text to display the timer
    public GameObject retryButtonGameObject; // Reference to the RetryButton GameObject

    private void Start()
    {
        timeRemaining = totalTime; // Set the initial time remaining
        UpdateTimerUI(); // Update the UI text to display the initial time

        // Hide the retry button when the game starts
        if (retryButtonGameObject != null)
        {
            retryButtonGameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!gameEnded && !gamePaused)
        {
            // Update the time remaining
            timeRemaining -= Time.deltaTime;

            // Check if the time has run out
            if (timeRemaining <= 0)
            {
                EndGame();
            }

            // Update the UI text to display the timer
            UpdateTimerUI();
        }
    }

    private void UpdateTimerUI()
    {
        // Convert the time remaining to minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Construct the timer text dynamically
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0f; // Freeze the game
        timerText.enabled = false; // Disable the timer text
        retryButtonGameObject.SetActive(true); // Make the RetryButton GameObject active
        Debug.Log("Game Over - You Lose!"); // You can replace this with your own game over logic
                                            // Perform any other actions you want when the game ends
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f; // Pause the game
        timerText.enabled = false; // Disable the timer text
        retryButtonGameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1f; // Resume the game
        timerText.enabled = true; // Enable the timer text
        retryButtonGameObject.SetActive(false);
    }
}
