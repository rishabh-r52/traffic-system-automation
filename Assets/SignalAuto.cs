using UnityEngine;
using System.Collections;

public class MoveUpAndDown : MonoBehaviour
{
    public float moveDistance = 20f; // Distance to move up
    public float moveSpeed = 5f; // Speed of movement
    public float holdTimeUp = 10f; // Time to hold at the top
    public float holdTimeDown = 30f; // Time to hold at the bottom
    public float startupHoldTime = 5f; // Time to hold at the start

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + Vector3.up * moveDistance;
        StartCoroutine(MoveCycle());
    }

    private IEnumerator MoveCycle()
    {
        // Hold at the start
        yield return new WaitForSeconds(startupHoldTime);

        while (true)
        {
            // Move up
            yield return StartCoroutine(MoveToPosition(targetPosition));

            // Hold at the top
            yield return new WaitForSeconds(holdTimeUp);

            // Move down
            yield return StartCoroutine(MoveToPosition(originalPosition));

            // Hold at the bottom
            yield return new WaitForSeconds(holdTimeDown);
        }
    }

    private IEnumerator MoveToPosition(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
    }
}
