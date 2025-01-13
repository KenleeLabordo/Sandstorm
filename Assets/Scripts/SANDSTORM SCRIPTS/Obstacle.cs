using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Move the obstacle to the right
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the obstacle touches the player
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destroy the player
            Debug.Log("Player has been killed!");
        }
    }
}
