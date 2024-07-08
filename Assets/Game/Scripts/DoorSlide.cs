using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float slideDistance = 2f;
    public float slideSpeed = 1f;
    private bool isOpen = false;
    private bool isMoving = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !isMoving)
        {
            StartCoroutine(SlideDoor());
        }
    }

    IEnumerator SlideDoor()
    {
        isMoving = true;
        Vector3 leftTargetPosition = leftDoor.localPosition + new Vector3(0, 0, isOpen ? -slideDistance : slideDistance);
        Vector3 rightTargetPosition = rightDoor.localPosition + new Vector3(0, 0, isOpen ? slideDistance : -slideDistance);

        while (Vector3.Distance(leftDoor.localPosition, leftTargetPosition) > 0.01f && Vector3.Distance(rightDoor.localPosition, rightTargetPosition) > 0.01f)
        {
            leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, leftTargetPosition, slideSpeed * Time.deltaTime);
            rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rightTargetPosition, slideSpeed * Time.deltaTime);
            yield return null;
        }

        leftDoor.localPosition = leftTargetPosition;
        rightDoor.localPosition = rightTargetPosition;
        isOpen = !isOpen;
        isMoving = false;
    }
}
