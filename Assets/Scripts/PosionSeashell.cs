using UnityEngine;

public class PosionSeashell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife(1);
            Destroy(gameObject);
        }
    }
}
