using UnityEngine;

public class RedSeashell : MonoBehaviour
{
    public float freezeDuration = 3f; // seconds Pinkalicious will be frozen

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Remove 2 golden seashells from score
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.LoseGoldenSeashells(2); // custom method we’ll add
                playerMovement.FreezePlayer(freezeDuration); // custom method we’ll add
            }

          GameManager.Instance.LoseLife(1);
            Destroy(gameObject);
        }
    }
}

