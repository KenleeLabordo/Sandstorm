using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Maximum time interval between pipe spawns
    [SerializeField] private float _maxTime = 1.5f;

    // Range for random vertical position of pipes
    [SerializeField] private float _heightRange = 0.45f;

    // Prefab for the pipe to spawn
    [SerializeField] private GameObject _pipe;

    // Timer to track time elapsed since the last spawn
    private float _timer;

    private void Start()
    {
        // Spawn the first pipe immediately when the game starts
        SpawnPipe();
    }

    private void Update()
    {
        // Check if the timer has exceeded the maximum time
        if (_timer > _maxTime)
        {
            SpawnPipe(); // Spawn a new pipe
            _timer = 0;  // Reset the timer
        }

        // Increment the timer based on the time elapsed since the last frame
        _timer += Time.deltaTime;
    }

    // Method to spawn a pipe at a random vertical position
    private void SpawnPipe()
    {
        // Calculate the spawn position with a random height offset
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        
        // Instantiate the pipe prefab at the calculated position with no rotation
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        // Destroy the pipe after 10 seconds to free up memory
        Destroy(pipe, 10f);
    }
}
