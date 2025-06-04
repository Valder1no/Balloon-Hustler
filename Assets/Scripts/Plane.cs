using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject[] planePrefabs;

    public Vector3 spawnCenter = Vector3.zero;
    public Vector3 spawnSize = new Vector3(0, 10, 0);

    public float moveSpeed;

    public float minSpawnInterval = 1f;
    private float maxSpawnInterval = 3f;

    public float spawnYOfsset = 25f;

    public GameObject camera;

    private List<GameObject> spawnedPlanes = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnPlanesWithInterval());
    }

    IEnumerator SpawnPlanesWithInterval()
    {
        while (true)
        {
            Vector3 randomPosition = spawnCenter + new Vector3(
                Random.Range(-spawnSize.x / 2, spawnSize.x / 2),
                Random.Range(-spawnSize.y / 2, spawnSize.y / 2),
                Random.Range(-spawnSize.z / 2, spawnSize.z / 2)
            );

            GameObject randomPlanePrefab = planePrefabs[Random.Range(0, planePrefabs.Length)];

            GameObject plane = Instantiate(randomPlanePrefab, randomPosition, randomPlanePrefab.transform.rotation);
            spawnedPlanes.Add(plane);

            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);
            Destroy(plane, 10f);
        }
    }

    void Update()
    {
        if (camera != null)
        {
            spawnCenter = new Vector3(
                spawnCenter.x,
                camera.transform.position.y + spawnYOfsset,
                spawnCenter.z
            );
        }

        foreach (GameObject plane in spawnedPlanes)
        {
            moveSpeed = Random.Range(7f, 15f);
            if (plane != null)
            {
                plane.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(spawnCenter, spawnSize);
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("tryna explodisioneding");
            if (other.CompareTag("Helicopter") || (other.CompareTag("Plane")))
            {
                Debug.Log("exploding");
                Destroy(gameObject);
            }
        }
    }
}
