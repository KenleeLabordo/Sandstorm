using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTooptions : MonoBehaviour
{
    // Method to load the Main Menu scene
    public void LoadOptions()
    {
        // Play button click sound
        SoundManager.Instance.PlayButtonClickSound();

        // Load the "OPTIONS" scene
        SceneManager.LoadScene("OPTIONS");
    }
}
