using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform startPoint; // Set this to the start of the level in the inspector

    public void Respawn()
    {
        // Reset position
        transform.position = startPoint.position;

        // Optional: reset velocity if using Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}