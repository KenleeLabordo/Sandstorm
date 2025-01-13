using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab for obstacles
    public float spawnInterval = 3f; // Adjusted spawn interval for reasonable time
    public float obstacleSpeed = 0.4f; // Speed of the obstacles
    public float spinForce = 0.3f; // Reduced spin force applied
    public int obstaclesPerSpawn = 1; // Number of obstacles to spawn per interval

    private float timer = 0f;
    private Collider2D spawnerBounds; // Collider to define the spawn area

    void Start()
    {
        // Get the Collider2D of the spawner object to determine the spawn area
        spawnerBounds = GetComponent<Collider2D>();

        if (spawnerBounds == null)
        {
            Debug.LogError("ObstacleSpawner requires a Collider2D to define its bounds!");
        }
    }

    void Update()
    {
        if (spawnerBounds == null) return;

        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn obstacles
        if (timer >= spawnInterval)
        {
            SpawnObstacles();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < obstaclesPerSpawn; i++)
        {
            // Generate a random position within the left side of the bounds
            Vector2 spawnPosition = GetRandomPositionOnLeftSide();

            // Instantiate the obstacle
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Add the Obstacle component
            Obstacle obstacleScript = obstacle.AddComponent<Obstacle>();
            obstacleScript.speed = obstacleSpeed;

            // Apply a minimal random rotational force
            Rigidbody2D rb = obstacle.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Prevent gravity from affecting the obstacle
            rb.AddTorque(Random.Range(-spinForce, spinForce));
        }
    }

    Vector2 GetRandomPositionOnLeftSide()
    {
        // Get the bounds of the Collider2D
        Bounds bounds = spawnerBounds.bounds;

        // Generate random x and y positions within the left side of the bounds
        float randomX = Random.Range(bounds.min.x, (bounds.min.x + bounds.max.x) / 2);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }
}
