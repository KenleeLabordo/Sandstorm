using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Score.instance != null)
            {
                Score.instance.UpdateScore();
                Debug.Log("Score updated successfully.");
            }
            else
            {
                Debug.LogError("Score instance is null. Ensure the Score script is properly initialized in the scene.");
            }
        }
    }
}
