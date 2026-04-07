using UnityEngine;
using UnityEngine.SceneManagement; // This allows us to change scenes

public class PirateShipTransition : MonoBehaviour
{
    [Header("Destination")]
    public string levelToLoad = "Level 4"; // You can change this in the Inspector

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Check if the Player hit the ship
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("Pinkalicious boarded the Pirate Ship! Loading Level 4...");

            // 2. Load the specific level
            SceneManager.LoadScene(levelToLoad);
            
            // Note: If you prefer using your SceneController, use:
            // SceneManager.LoadScene("Level 4");
        }
    }
}
