using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");

        // Reset time scale to unfreeze the game
        Time.timeScale = 1f;
    }
}
