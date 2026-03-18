using UnityEngine;
using System.Collections; // Needed for the timer!

public class RedSeashell : MonoBehaviour
{
    public float freezeDuration = 3f; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.LoseGoldenSeashells(2);
                
                // Start a timer to freeze her for a few seconds
                StartCoroutine(FreezeTimer(playerMovement));
            }

            // Safety check: only call GameManager if it exists
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseLife(1);
            }

            // Hide the shell immediately so she doesn't hit it twice
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 4f); // Destroy fully after the freeze is over
        }
    }

    IEnumerator FreezeTimer(PlayerMovement player)
    {
        player.FreezePlayer(true);  // Turn off movement
        yield return new WaitForSeconds(freezeDuration);
        player.FreezePlayer(false); // Turn movement back on
    }
}