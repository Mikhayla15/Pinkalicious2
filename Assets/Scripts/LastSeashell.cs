using UnityEngine;

public class LastSeashell : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
      
        Debug.Log("Switching to Level 2 now!"); 
        SceneController.instance.NextLevel();
        
        GetComponent<Collider2D>().enabled = false; 
    }
}
}