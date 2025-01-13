using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas; // Reference to the Game Over Canvas

    private void Start()
    {
        // Ensure the game starts with normal time scale
        Time.timeScale = 1f;

        // Hide the Game Over canvas initially
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Handle player death
            Die();
        }
    }

    private void Die()
    {
        // Play the death sound using SoundManager
        SoundManager.Instance.PlayPlayerDeathSound();

        // Show Game Over screen
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // Pause the game
        Time.timeScale = 0f;

        Debug.Log("Player has died!");
    }

    // Restart the game by reloading the current scene (can be called via a UI button)
    public void RestartGame()
    {
        // Play button click sound
        SoundManager.Instance.PlayButtonClickSound();

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("Game restarted.");
    }

    // Load the main menu scene (can be called via a UI button)
    public void LoadMainMenu()
    {
        // Play button click sound
        SoundManager.Instance.PlayButtonClickSound();

        // Ensure the time scale is reset before transitioning
        Time.timeScale = 1f;

        // Load the "MAIN MENU" scene
        SceneManager.LoadScene("MAIN MENU");

        Debug.Log("Returning to Main Menu.");
    }
}
