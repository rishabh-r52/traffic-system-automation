using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs; // Assign the car prefabs in the inspector
    public GameObject mainCar; // Reference to the MainCar GameObject
    public int maxCars = 25;
    private int carsSpawned = 0;
    public float spawnInterval = 2.0f; // Adjust this to change the spawn interval

    private bool isColliding = false;

    void OnTriggerEnter(Collider other)
    {
        // When something enters the trigger, set isColliding to true
        if (other.gameObject != mainCar)
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // When something exits the trigger, set isColliding to false
        if (other.gameObject != mainCar)
        {
            isColliding = false;
        }
    }

    void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (carsSpawned < maxCars)
        {
            // Check if there is no collision
            if (!isColliding)
            {
                // Spawn a car
                SpawnCar();
                carsSpawned++;

                // Wait for the specified interval before spawning the next car
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                // Wait for a short period before checking again
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void SpawnCar()
    {
        // Randomly select a car prefab from the array
        int randomIndex = Random.Range(0, carPrefabs.Length);
        GameObject selectedCarPrefab = carPrefabs[randomIndex];

        // Instantiate the selected car prefab at the spawner's location and rotation
        GameObject car = Instantiate(selectedCarPrefab, transform.position - Vector3.up * 0.43f, transform.rotation);

        // Copy the FollowWaypoints component from the mainCar to the newly spawned car
        FollowWaypoints mainCarFollowWaypoints = mainCar.GetComponent<FollowWaypoints>();
        FollowWaypoints carFollowWaypoints = car.GetComponent<FollowWaypoints>();

        if (mainCarFollowWaypoints != null && carFollowWaypoints != null)
        {
            carFollowWaypoints.waypoints = mainCarFollowWaypoints.waypoints;
            carFollowWaypoints.speed = Random.Range(5f, 20f); // Assign a random speed to the car
        }
    }
}
