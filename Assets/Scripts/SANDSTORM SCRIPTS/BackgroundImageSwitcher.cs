using UnityEngine;
using System.Collections;

public class BackgroundImageSwitcher : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundRenderer; // Reference to the SpriteRenderer
    [SerializeField] private Sprite alternateImage; // Alternate image to switch to
    [SerializeField] private float switchInterval = 5f; // Time interval for switching images
    [SerializeField] private float fadeDuration = 1f; // Duration of the fade transition

    private Sprite originalImage; // Store the original image

    private void Start()
    {
        if (backgroundRenderer != null && alternateImage != null)
        {
            originalImage = backgroundRenderer.sprite; // Store the original sprite
            InvokeRepeating(nameof(SwitchToAlternateImage), switchInterval, switchInterval * 2);
        }
    }

    private void SwitchToAlternateImage()
    {
        if (backgroundRenderer != null)
        {
            StartCoroutine(FadeTransition(alternateImage));
            Debug.Log($"Switched to alternate image. {switchInterval} seconds until it switches back to the original image.");
            Invoke(nameof(SwitchToOriginalImage), switchInterval);
        }
    }

    private void SwitchToOriginalImage()
    {
        if (backgroundRenderer != null)
        {
            StartCoroutine(FadeTransition(originalImage));
            Debug.Log($"Switched back to original image. {switchInterval} seconds until it switches to the alternate image.");
        }
    }

    private IEnumerator FadeTransition(Sprite targetImage)
    {
        float elapsedTime = 0f;
        Color initialColor = backgroundRenderer.color;

        // Fade out
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            backgroundRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        backgroundRenderer.sprite = targetImage;
        elapsedTime = 0f;

        // Fade in
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            backgroundRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        backgroundRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f); // Ensure full opacity
    }
}
