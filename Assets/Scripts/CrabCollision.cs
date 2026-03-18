using UnityEngine;

public class CrabCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object hitting the crab is the player
        if (other.CompareTag("Player"))
        {
            // Get the PlayerRespawn script on the player
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();

            if (playerRespawn != null)
            {
                // Reduce player's lives
                GameManager.Instance.LoseLife();

                // Reset the player to the start of the level
                playerRespawn.Respawn();
            }
        }
    }
}