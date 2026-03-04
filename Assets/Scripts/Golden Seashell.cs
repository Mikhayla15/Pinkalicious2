using UnityEngine;

public class GoldenSeashell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddSeashells(3);
            PlayerMovement.Instance.SpeedBoost(0.2f, 10f);

            Destroy(gameObject);
        }
    }
}
