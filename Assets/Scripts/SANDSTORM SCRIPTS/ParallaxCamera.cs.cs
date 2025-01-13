using UnityEngine;

[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;

    private float oldPosition;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player object is not assigned to the ParallaxCamera script.");
            enabled = false;
            return;
        }

        oldPosition = transform.position.x;
    }

    void LateUpdate()
    {
        // Follow the player
        if (player != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = player.position.x; // Update the camera's x position to follow the player
            transform.position = newPosition;
        }

        // Parallax effect
        if (transform.position.x != oldPosition)
        {
            float delta = oldPosition - transform.position.x;
            onCameraTranslate?.Invoke(delta);
            oldPosition = transform.position.x;
        }
    }
}
