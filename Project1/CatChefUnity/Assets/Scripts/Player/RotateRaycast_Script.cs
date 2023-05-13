using UnityEngine;
using System.Collections;

public class RotateRaycast_Script : MonoBehaviour
{
    public Vector2 pivotPoint = Vector2.zero;
    public float range = 5.0f;
    public float angle = 45.0f;

    private Vector2 startPoint = Vector2.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startPoint = (Vector2)transform.position + pivotPoint; // Update starting ray point.

        // Direct use.
        // Get normalized (of length = 1) distance vector.
        // Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized; 

        // Using function.
        Vector2 direction = GetDirectionVector2D(angle);

        Physics2D.Raycast(startPoint, direction, range); // Shot ray.

        // Draw ray. For Debug we have to multiply our direction vector. 
        // Even if there is said Debug.DrawRay(start, dir), not Debug.DrawRay(start, end). Keep that in mind.
        Debug.DrawRay(startPoint, direction * range, Color.red);

    }

    public Vector2 GetDirectionVector2D(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }
}