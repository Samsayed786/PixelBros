using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public GameObject leftPanel;
    public GameObject rightPanel;
    public float openSpeed = 1.0f; 
    public float openAngle = 90f; 

    private bool isOpening = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
        }
    }

    void Update()
    {
        if (isOpening)
        {
            float step = openSpeed * Time.deltaTime;
            Quaternion leftTargetRotation = Quaternion.Euler(0, -openAngle, 0);
            Quaternion rightTargetRotation = Quaternion.Euler(0, openAngle, 0);

            leftPanel.transform.localRotation = Quaternion.RotateTowards(leftPanel.transform.localRotation, leftTargetRotation, step);
            rightPanel.transform.localRotation = Quaternion.RotateTowards(rightPanel.transform.localRotation, rightTargetRotation, step);

            if (Quaternion.Angle(leftPanel.transform.localRotation, leftTargetRotation) < 0.1f && Quaternion.Angle(rightPanel.transform.localRotation, rightTargetRotation) < 0.1f)
            {
                isOpening = false; // Stop opening once the door is fully opened
            }
        }
    }
}

