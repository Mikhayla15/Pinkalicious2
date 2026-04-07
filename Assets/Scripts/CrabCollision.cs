using UnityEngine;

public class CrabCollision : MonoBehaviour
{
    public int damage = 1;
    public float hitCooldown = 1.5f; // Time before the crab can hurt player again
    private float lastHitTime;
    
    private void OnTriggerEnter2D(Collider2D other)
   {
    if (other.CompareTag("Player"))
        {
            // 2. Subtract the life
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseLife(1);
                Debug.Log("Ouch! You have " + GameManager.Instance.lives + " lives left.");
            }

            // 3. Get the PlayerMovement script (Use the EXACT name of your script file)
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            
            if (playerScript != null)
            {
                // 4. Call the function you wrote in PlayerMovement
                playerScript.ResetToStart(); 
               
            }
            
        }
   }
}