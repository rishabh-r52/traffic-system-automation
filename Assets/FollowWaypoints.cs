using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public float[] waitTimes; // Array to store wait times for each waypoint
    int currentWP = 0;
    public float speed = 10f;
    public float timeRemaining;
    public bool stopAtSignal = false;

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Length != waitTimes.Length)
        {
            Debug.LogError("The number of waypoints and wait times must be the same.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeRemaining);

        if (stopAtSignal)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0.1f)
            {
                stopAtSignal = false;
            }
        }
        else
        {
            if (IsObstacleInFront())
            {
                // If there's an obstacle in front, stop the car
                return;
            }

            if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
            {
                stopAtSignal = true;
                timeRemaining = waitTimes[currentWP]; // Set the time remaining to the current waypoint's wait time
                currentWP = (currentWP + 1) % waypoints.Length;
            }

            if (!stopAtSignal)
            {
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }

                this.transform.LookAt(waypoints[currentWP].transform);
                this.transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }
    }

    // Method to check if there is an obstacle in front of the car
    bool IsObstacleInFront()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 5f;

        Debug.DrawRay(transform.position, forward, Color.red);

        if (Physics.Raycast(transform.position, forward, out hit, 5f))
        {
            // Here you can filter by tag or layer manually if needed
            if (hit.collider.CompareTag("Obstacle")) // Check for a specific tag
            {
                Debug.Log("Obstacle detected: " + hit.collider.name);
                return true;
            }
        }

        return false;
    }
}
