using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public float backgroundSpeed = 3f;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        // Constant leftward movement
        startpos -= backgroundSpeed * Time.deltaTime;
        transform.position = new Vector3(startpos, transform.position.y, transform.position.z);

        // Loop background
        if (startpos < -length)
            startpos += length;
    }
}
