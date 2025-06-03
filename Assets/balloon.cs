using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BalloonBehavior : MonoBehaviour
{
    [Header("Balloon Settings")]
    public float liftForce = 5f;
    public float maxLiftSpeed = 2f;
    public float wobbleAmount = 0.1f;
    public float wobbleSpeed = 1f;

    private Rigidbody rb;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Apply upward force if below max speed
        if (rb.linearVelocity.y < maxLiftSpeed)
        {
            rb.AddForce(Vector3.up * liftForce, ForceMode.Acceleration);
        }

        // Optional: add a wobble effect
        Vector3 wobble = new Vector3(
            Mathf.Sin(Time.time * wobbleSpeed),
            0,
            Mathf.Cos(Time.time * wobbleSpeed)
        ) * wobbleAmount;

        rb.AddForce(wobble, ForceMode.Acceleration);
    }
}