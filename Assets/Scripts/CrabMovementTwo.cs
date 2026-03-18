using UnityEngine;

public class CrabMovementTwo : MonoBehaviour
{
    public Transform pointC; // Start point
    public Transform pointD; // End point
    public float speed = 2f; // Movement speed

    private Transform target; // Current target

    void Start()
    {
        if (pointC == null || pointD == null)
        {
            Debug.LogError("Point C or D is not assigned for " + gameObject.name);
            enabled = false;
            return;
        }

        target = pointD; // Start moving towards D
    }

    void Update()
    {
        // Move crab towards current target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Switch direction when target reached
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointC ? pointD : pointC;
        }

        // Optional: Flip sprite based on direction
        Vector3 scale = transform.localScale;
        scale.x = target == pointD ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    // Optional: visualize the path in the Scene view
    void OnDrawGizmos()
    {
        if (pointC != null && pointD != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(pointC.position, pointD.position);
        }
    }
}