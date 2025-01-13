using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bilang : MonoBehaviour
{
    public static Bilang instance; // Singleton pattern

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        // Ensure there's only one instance of the class
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of Bilang detected. Destroying duplicate...");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Ensure the TextMeshProUGUI components are assigned
        if (_currentScoreText == null)
        {
            Debug.LogError("Current Score Text is not assigned. Please assign it in the Inspector.");
        }
        if (_highScoreText == null)
        {
            Debug.LogError("High Score Text is not assigned. Please assign it in the Inspector.");
        }

        // Initialize score texts
        _currentScoreText.text = _score.ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void UpdateHighScore()
    {
        // Update and save the high score if the current score exceeds it
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
            Debug.Log("New high score achieved: " + _score);
        }
    }

    public void UpdateScore()
    {
        _score++;
        
        // Ensure the current score text is updated
        if (_currentScoreText != null)
        {
            _currentScoreText.text = _score.ToString();
        }
        else
        {
            Debug.LogError("Current Score Text is null. Cannot update score display.");
        }

        // Update high score after updating the current score
        UpdateHighScore();
    }
}
