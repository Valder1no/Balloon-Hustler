using UnityEngine;
using UnityEngine.SceneManagement;

public class KoferTouched : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kofer"))
        {
            Debug.Log("WON");
        }
    }
}
