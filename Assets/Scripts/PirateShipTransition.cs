using UnityEngine;
using UnityEngine.SceneManagement; 

public class PirateShipTransition : MonoBehaviour
{
    [Header("Destination")]
    public string levelToLoad = "Level 4"; 

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
            
        }
    }
}
