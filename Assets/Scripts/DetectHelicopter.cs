using UnityEngine;

public class PlayerAttraction : MonoBehaviour
{
    private Rigidbody rb;
    private Transform currentHelicopter;

    public float pullForce = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Helicopter"))
        {
            currentHelicopter = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Helicopter") && other.transform == currentHelicopter)
        {
            currentHelicopter = null;
        }
    }

    void FixedUpdate()
    {
        if (currentHelicopter != null)
        {
            Vector3 direction = (currentHelicopter.position - transform.position).normalized;
            rb.AddForce(direction * pullForce);
        }
    }
}
