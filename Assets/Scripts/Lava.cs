using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    public float scaleSpeed = 1f; // How fast the object scales up
    private Vector3 initialScale;

    void Start()
    {
        // Store the initial scale of the object
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Increase the Y scale over time
        float newYScale = transform.localScale.y + scaleSpeed * Time.deltaTime;
        transform.localScale = new Vector3(initialScale.x, newYScale, initialScale.z);
    }
}
