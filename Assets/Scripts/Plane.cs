using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner2D : MonoBehaviour
{
    public GameObject planePrefab;

    public Vector3 spawnCenter = Vector3.zero;
    public Vector3 spawnSize = new Vector3(10, 10, 0); // Z = 0 for 2D

    public float moveSpeed = 7f;
    public int maxPlanes = 20;

    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 3f;

    private List<GameObject> spawnedPlanes = new List<GameObject>();
    private List<Vector3> planeDirections = new List<Vector3>();

    void Start()
    {
        StartCoroutine(SpawnPlanes());
    }

    IEnumerator SpawnPlanes()
    {
        while (spawnedPlanes.Count < maxPlanes)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            // Random direction: up means "right", down means "left" in your setup
            Vector3 randomDirection = (Random.value > 0.5f) ? Vector3.up : Vector3.down;

            Vector3 spawnPosition;

            if (randomDirection == Vector3.up) // going right
            {
                // Spawn along top horizontal line
                spawnPosition = new Vector3(
                    Random.Range(spawnCenter.x - spawnSize.x / 2, spawnCenter.x + spawnSize.x / 2),
                    spawnCenter.y + spawnSize.y / 2,
                    spawnCenter.z
                );
            }
            else // going left
            {
                // Spawn along vertical line offset from left edge by 1/4 width toward center
                float leftSpawnLineX = spawnCenter.x - spawnSize.x / 2 + spawnSize.x / 4f;

                spawnPosition = new Vector3(
                    leftSpawnLineX,
                    Random.Range(spawnCenter.y - spawnSize.y / 2, spawnCenter.y + spawnSize.y / 2),
                    spawnCenter.z
                );
            }

            GameObject newPlane = Instantiate(planePrefab, spawnPosition, planePrefab.transform.rotation);
            spawnedPlanes.Add(newPlane);
            planeDirections.Add(randomDirection);

            Destroy(newPlane, 5f);
        }
    }

    void Update()
    {
        // Clean up null entries
        for (int i = spawnedPlanes.Count - 1; i >= 0; i--)
        {
            if (spawnedPlanes[i] == null)
            {
                spawnedPlanes.RemoveAt(i);
                planeDirections.RemoveAt(i);
            }
        }

        // Move all planes in their respective directions
        for (int i = 0; i < spawnedPlanes.Count; i++)
        {
            spawnedPlanes[i].transform.Translate(planeDirections[i] * moveSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnCenter, spawnSize);
    }
}
