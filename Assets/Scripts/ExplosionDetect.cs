using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public ParticleSystem explosionPrefab;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered by: {other.name}");
        if (other.CompareTag("Plane"))
        {
            Explosionising();
            Debug.Log("Boom!");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    void Explosionising() 
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}