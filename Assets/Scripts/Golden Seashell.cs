using UnityEngine;

public class GoldenSeashell : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.AddGoldenSeashell();
            }

            Destroy(gameObject);
        }
    }
}