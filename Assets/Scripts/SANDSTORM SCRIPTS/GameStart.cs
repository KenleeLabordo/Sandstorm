using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Method to load the Main Menu scene
    public void clickGameStart()
    {
        // Play button click sound
        SoundManager.Instance.PlayButtonClickSound();

        // Load the "MAIN MENU" scene
        SceneManager.LoadScene("LEVEL 1");
    }
}
