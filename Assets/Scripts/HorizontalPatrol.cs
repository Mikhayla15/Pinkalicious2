using UnityEngine;

public class HorizontalPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f; // How far it moves left and right
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new X position using a Sine wave for smooth back-and-forth
        float newX = startPos.x + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(newX, startPos.y, startPos.z);
        
        // Optional: Flip the turtle sprite based on direction
        if (Mathf.Cos(Time.time * speed) > 0)
            transform.localScale = new Vector3(1, 1, 1); // Facing Right
        else
            transform.localScale = new Vector3(-1, 1, 1); // Facing Left
    }
}

