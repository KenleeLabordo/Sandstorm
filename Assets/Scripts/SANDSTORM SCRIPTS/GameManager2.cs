using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;

    [SerializeField] private GameObject _gameOverCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Call this method when the player dies
    public void PlayerDied()
    {
        GameOver();
    }
}
