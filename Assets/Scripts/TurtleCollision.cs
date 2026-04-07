using UnityEngine;

public class TurtleCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Lose a life
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseLife(1);
            }

            // 2. Reset Pinkalicious
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ResetToStart();
                Debug.Log("Sea Turtle hit! Pinkalicious sent back to start.");
            }
        }
    }
}