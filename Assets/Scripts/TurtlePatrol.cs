using UnityEngine;

public class TurtlePatrol : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f; // How far it goes before turning around
    public bool moveVertical = false; // Check this in Inspector for Up/Down movement

    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (moveVertical)
        {
            transform.Translate(Vector2.up * speed * direction * Time.deltaTime);
            if (transform.position.y > startPosition.y + moveDistance || transform.position.y < startPosition.y - moveDistance)
            {
                direction *= -1; // Turn around
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
            if (transform.position.x > startPosition.x + moveDistance || transform.position.x < startPosition.x - moveDistance)
            {
                direction *= -1; // Turn around
                FlipSprite();
            }
        }
    }

    void FlipSprite()
    {
        // This flips the turtle's image so it faces the right way
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
