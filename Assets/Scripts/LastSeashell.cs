using UnityEngine;

public class LastSeashell : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        // Add this line to see if it's working in the Console
        Debug.Log("Switching to Level 2 now!"); 
        SceneController.instance.NextLevel();
        
        // Disable the collider so it doesn't trigger 100 times
        GetComponent<Collider2D>().enabled = false; 
    }
}
}