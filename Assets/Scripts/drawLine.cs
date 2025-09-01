using UnityEngine;

public class drawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [Header("Line Points")]
    public Transform pointA; // starting point

    void Start()
    {
        // Get LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Set number of positions
        lineRenderer.positionCount = 2;
    }
    public void soulLine(Vector3 pointB)
    {
        if (pointA != null && pointB != null)
        {
            // Set positions of the line
            lineRenderer.SetPosition(0, pointA.position);
            lineRenderer.SetPosition(1, pointB);
        }
    }
}
