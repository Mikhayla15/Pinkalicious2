using UnityEngine;

public class sandcastle : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.CanFreeMermaid())
            {
                Debug.Log("Mermaid Freed!");
                // Add crumble animation here
            }
            else
            {
                int needed = GameManager.Instance.requiredSeashells - GameManager.Instance.seashells;
                Debug.Log("Not enough treasure! Go find " + needed + " more!");
            }
        }
    }
    
}
