using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is tagged as "Obstacle"
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject); // Destroy the obstacle
            Debug.Log($"Destroyed {collision.gameObject.name} upon entering despawner trigger.");
        }
    }
}
