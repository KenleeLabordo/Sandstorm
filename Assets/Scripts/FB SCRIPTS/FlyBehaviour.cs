using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Ensure the new Input System is used.

public class FlyBehavior : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the GameObject!");
        }
    }

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * _velocity;
        }
        else if (Mouse.current == null)
        {
            Debug.LogError("Mouse input is not properly configured. Check Input System settings.");
        }
    }

    private void FixedUpdate()
    {
        // Smooth rotation based on velocity
        float angle = Mathf.Clamp(_rb.velocity.y * _rotationSpeed, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }
        else
        {
            Debug.LogError("GameManager instance is not set. Ensure GameManager script is properly configured.");
        }
    }
}
