using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;
    private float timeRemaining;
    private int score = 0;
    private bool gameEnded = false;
    private bool gamePaused = false; 

    public Text timerText;
    public Text scoreText;
    public Text finalScoreText;
    public Text winLoseText;
    public GameObject retryButtonGameObject;
    public GameObject backgroundGameObject;
    public AudioSource SFX;
    public AudioClip sfx1, sfx2;

    public float sfx1Volume = 0.3f;


    private void Start()
    {
        timeRemaining = totalTime;
        UpdateTimerUI();
        scoreText.text = "Score: 0";

        if (retryButtonGameObject != null)
        {
            retryButtonGameObject.SetActive(false);
        }
        winLoseText.gameObject.SetActive(false);
        backgroundGameObject.SetActive(false);
    }

    private void Update()
    {
        if (!gameEnded && !gamePaused)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                EndGame();
            }

            UpdateTimerUI();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;
        timerText.enabled = false;
        scoreText.enabled = false;
        backgroundGameObject.SetActive(true);
        retryButtonGameObject.SetActive(true);

        // Show final score
        finalScoreText.text = "Final Score: " + score;

        winLoseText.gameObject.SetActive(true);

        if (score >= 10)
        {
            Debug.Log("You Won!");
            SFX.clip = sfx1;
            SFX.volume = sfx1Volume;
            SFX.Play();
            EndGameWin(); // Win
        }
        else
        {
            Debug.Log("You Lost!");
            SFX.clip = sfx2;
            SFX.Play();
            EndGameLose(); // Lose
        }

    }
    public void IncrementScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        timerText.enabled = false;
        scoreText.enabled = false;
        retryButtonGameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        timerText.enabled = true;
        scoreText.enabled = true; 
        retryButtonGameObject.SetActive(false);
    }

    public void EndGameWin()
    {
        winLoseText.text = "YOU WIN!";
    }

    public void EndGameLose()
    {
        winLoseText.text = "YOU LOSE!";
    }

}
