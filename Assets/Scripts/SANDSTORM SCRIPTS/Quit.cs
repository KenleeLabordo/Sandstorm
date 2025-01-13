using UnityEngine;

#if UNITY_EDITOR
using UnityEditor; // Required for Editor-specific functionality
#endif

public class QuitGame : MonoBehaviour
{
    // Method to quit the game
    public void Quit()
    {
        // Play button click sound
        SoundManager.Instance.PlayButtonClickSound();

        // Logs a message for debugging (only visible in the editor)
        Debug.Log("Game is stopping...");

        #if UNITY_EDITOR
        // Stops the play mode in the Editor
        EditorApplication.isPlaying = false;
        #else
        // Exits the application in standalone builds
        Application.Quit();
        #endif
    }

    private void Start()
    {
        // Optional: Log a message to confirm the script is attached and active
        Debug.Log("QuitGame script is active and ready.");
    }
}
