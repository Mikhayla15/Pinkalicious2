using UnityEngine;

public class PosionSeashell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddSeashells(-2);
            PlayerMovement.Instance.SpeedBoost(-0.1f, 15f);

            Destroy(gameObject);
        }
    }
}
