using UnityEngine;

public class HelicopterAttractor : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float pullStrength = 5f;
    public LayerMask Player;  // Assign only the Player layer in Inspector

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, Player);
        foreach (Collider hit in hits)
        {
            Debug.Log("getting pulled");
            Rigidbody rb = hit.attachedRigidbody;
            if (rb != null)
            {
                Debug.Log("getting pulled ACTUALY");
                Vector3 directionToHelicopter = (transform.position - rb.position).normalized;
                rb.AddForce(directionToHelicopter * pullStrength, ForceMode.Acceleration);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
