using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton instance
    public static SoundManager Instance;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip buttonClickSound; // Button click sound
    [SerializeField] private AudioClip playerDeathSound; // Player death sound
    [SerializeField] private AudioClip scoreSound;       // Score sound

    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance of SoundManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Play a specific sound
    public void PlayButtonClickSound()
    {
        PlaySound(buttonClickSound);
    }

    public void PlayPlayerDeathSound()
    {
        PlaySound(playerDeathSound);
    }

    public void PlayScoreSound()
    {
        PlaySound(scoreSound);
    }

    // Helper function to play a sound
    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("No audio clip assigned!");
        }
    }
}
