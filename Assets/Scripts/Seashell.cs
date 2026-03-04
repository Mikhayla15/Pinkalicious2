using UnityEngine;

public class Seashell : MonoBehaviour
{

    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seshell"))
        {
            GameManager.Instance.seashells += 1;
            Destroy(gameObject);
              Debug.Log("Touched a seashell!");
        }
    }
}
