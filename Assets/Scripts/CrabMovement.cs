using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    public Transform pointA; // Left / start point
    public Transform pointB; // Right / end point
    public float speed = 2f;

    private Transform target; // current movement target

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Point A or B is not assigned!");
            enabled = false;
            return;
        }

        target = pointB; // start moving towards B
    }

    void Update()
    {
        // Move towards target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Switch target when reaching it
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }

    // Optional: visualize points in Scene view
    void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}