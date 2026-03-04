using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    private float baseSpeed;
    public bool canMove = true;

    [Header("Swimming Effect")]
    public float floatAmplitude = 0.1f;
    public float floatFrequency = 1f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseSpeed = moveSpeed;
    }

    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime;

        // Floating motion
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        newPosition.y += floatOffset;

        rb.MovePosition(newPosition);
    }

    public void SpeedBoost(float percent, float duration)
    {
        StartCoroutine(BoostCoroutine(percent, duration));
    }

    IEnumerator BoostCoroutine(float percent, float duration)
    {
        moveSpeed = baseSpeed * (1 + percent);

        yield return new WaitForSeconds(duration);

        moveSpeed = baseSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}