using UnityEngine;
using System.Collections;

public class RedSeashell : MonoBehaviour
{
    public float freezeDuration = 3f;
    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                StartCoroutine(FreezeTimer(playerMovement));
            }

            GameManager.Instance.LoseLife(1);

            // Hide the shell immediately so it looks gone
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Fix: Wait slightly longer than the freeze duration before destroying
            // This ensures the Coroutine finishes unfreezing the player first.
            Destroy(gameObject, freezeDuration + 0.5f);
        }
    }

    IEnumerator FreezeTimer(PlayerMovement player)
    {
        player.FreezePlayer(true);
        yield return new WaitForSeconds(freezeDuration);
        player.FreezePlayer(false); 
        Debug.Log("Pinkalicious unfrozen!"); 
    }
}