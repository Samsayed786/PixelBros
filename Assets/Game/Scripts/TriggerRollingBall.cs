using System.Collections;
using UnityEngine;

public class TriggerMultipleRollingBalls : MonoBehaviour
{
    public GameObject[] balls; // Assign the ball GameObjects in the Inspector
    public Vector3 forceDirection; // Set the direction of the force in the Inspector
    public float forceMagnitude = 10f; // Set the magnitude of the force in the Inspector
    public float delay = 2f; // Set the delay time in the Inspector

    private Rigidbody[] ballRigidbodies;

    void Start()
    {
        ballRigidbodies = new Rigidbody[balls.Length];
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i] != null)
            {
                ballRigidbodies[i] = balls[i].GetComponent<Rigidbody>();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RollBallsAfterDelay());
        }
    }

    private IEnumerator RollBallsAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        foreach (Rigidbody ballRigidbody in ballRigidbodies)
        {
            if (ballRigidbody != null)
            {
                ballRigidbody.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
