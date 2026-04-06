using UnityEngine;
using System.Collections;

public class RedSeashell : MonoBehaviour
{
    public float freezeDuration = 3f;
    private bool hasTriggered = false;
    public GameObject frozentext; 

    private void Start()
    {
        // Automatically find the text if the slot is empty
        if (frozentext == null)
        {
            frozentext = GameObject.Find("frozentext");
        }
        if (frozentext != null)
        {
            frozentext.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (!hasTriggered && other.CompareTag("Player"))
        {
            if (hasTriggered) return; // Mark as triggered IMMEDIATELY
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("REDUCING LIFE NOW");

            if (GameManager.Instance != null)
            {
                // Force it to subtract exactly 1
                GameManager.Instance.LoseLife(1); 
                Debug.Log("Current Lives in Manager: " + GameManager.Instance.lives);
            }

            // 2. Disable everything so it can't hit again
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            // 3. Start the freeze
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null) StartCoroutine(FreezeSequence(player));
        }
    }

    private IEnumerator FreezeSequence(PlayerMovement player)
    {
        if (frozentext != null) frozentext.SetActive(true);
        player.FreezePlayer(true);

        yield return new WaitForSeconds(freezeDuration);

        if (frozentext != null) frozentext.SetActive(false);
        player.FreezePlayer(false);

        Destroy(gameObject); // Remove shell from scene after freeze is over
    }
}