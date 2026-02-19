using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 2f; 

    public float jumpHeight = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                // Get the current position of the player
                Vector2 currentPosition = gameObject.transform.position;

                // Get new position by adding to the x coordinate 
                Vector2 newPos = new Vector2(currentPosition.x + Time.deltaTime * speed, currentPosition.y);

                //update the player's position
                gameObject.transform.position = newPos;
            }

            if(Input.GetKey(KeyCode.LeftArrow))
            {
                // Get the current position of the player
                Vector2 currentPosition = gameObject.transform.position;

                // Get new position by adding to the x coordinate 
                Vector2 newPos = new Vector2(currentPosition.x - Time.deltaTime * speed, currentPosition.y);

                //update the player's position
                gameObject.transform.position = newPos;
            }
            if(Input.GetKey(KeyCode.Space))
            {
                // Get the current position of the player
                Vector2 currentPosition = gameObject.transform.position;

                // Get new position by adding to the x coordinate 
                Vector2 newPos = new Vector2(currentPosition.x, currentPosition.y + jumpHeight);

                //update the player's position
                gameObject.transform.position = newPos;
            }
     public class Coin : MonoBehaviour
    {
    public int points = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"Coin triggered by {other.name}");
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Seashell collected!");
            GameManager.Instance.AddScore(points);
            Destroy(gameObject);
        }
    }
    }
}
