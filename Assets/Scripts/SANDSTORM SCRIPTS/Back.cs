using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    // Method to load the Main Menu scene
    public void LoadMainMenu()
    {
        // Play button click sound
        SoundManager.Instance.PlayButtonClickSound();

        // Load the "MAIN MENU" scene
        SceneManager.LoadScene("MAIN MENU");
    }
}
