using UnityEngine;

public class Sandtrap : MonoBehaviour
{
    
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddSeashells(-2);
            PlayerMovement.Instance.ResetSpeed();
        }
    }
}
