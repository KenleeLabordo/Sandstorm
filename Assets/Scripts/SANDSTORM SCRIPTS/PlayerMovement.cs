using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input from arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Update player position
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
       private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance != null)
        {
            GameManager2.instance.GameOver();
        }
        
    }

}
