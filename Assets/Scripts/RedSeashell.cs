using UnityEngine;
using System.Collections;

public class RedSeashell : MonoBehaviour
{
    public float freezeDuration = 3f;
    private bool hasTriggered = false;

    public GameObject frozentext; 

    private void Awake()
    {
        // Automatically find the text if you forgot to drag it in
        if (frozentext == null)
        {
            frozentext = GameObject.Find("frozentext");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        // Make sure your player object has the "Player" Tag in the Inspector!
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                StartCoroutine(FreezeTimer(playerMovement));
            }

            // Check if GameManager exists before calling LoseLife
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseLife(1);
            }

            // Hide the shell so it looks like it's gone, but it's still running the script
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private IEnumerator FreezeTimer(PlayerMovement player)
    {
        // 1. Show the "You're Frozen" text
        if (frozentext != null) 
        {
            frozentext.SetActive(true);
        }

        // 2. Freeze the player
        player.FreezePlayer(true);

        // 3. Wait
        yield return new WaitForSeconds(freezeDuration);

        // 4. Unfreeze the player and hide the text
        player.FreezePlayer(false);
        
        if (frozentext != null)
        {
            frozentext.SetActive(false);
        }

        // 5. NOW destroy the shell object
        Destroy(gameObject);
    }
}