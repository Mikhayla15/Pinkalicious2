using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public ParticleSystem bubbles;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            if (!bubbles.isPlaying)
                bubbles.Play();
        }
        else
        {
            bubbles.Stop();
        }
    }
}

