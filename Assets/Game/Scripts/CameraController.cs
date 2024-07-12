using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public float maxVerticalAngle = 80f;
    public Transform body;
    private RaycastHit hit;
    private float _mouseVerticalValue;
    private Vector3 camOffset;
    private Vector3 currentCamPosition;

    [Header("Zoom Settings")]
    public float zoomSpeed = 5f; // Speed of the zoom transition
    public float zoomDistance = 0.5f; // How much closer the camera moves to the player when zooming

    [Header("Obstacle Detection")]
    public LayerMask obstacleLayers; // Layers to detect as obstacles

    private float MouseVerticalValue
    {
        get => _mouseVerticalValue;
        set
        {
            float verticalAngle = _mouseVerticalValue + value;
            verticalAngle = Mathf.Clamp(verticalAngle, -maxVerticalAngle, maxVerticalAngle);
            _mouseVerticalValue = verticalAngle;
        }
    }

    public float sensitivity = 2f;

    private void Start()
    {
        camOffset = cameraTransform.localPosition;
        currentCamPosition = camOffset;
    }

    private void Update()
    {
        HandleCameraZoom();
        HandleCameraRotation();
        HandleCursorLock();
    }

    private void HandleCameraZoom()
    {
        Vector3 desiredCamPosition = camOffset;

        if (Physics.Linecast(transform.position, transform.position + transform.localRotation * camOffset, out hit, obstacleLayers))
        {
            float distance = Vector3.Distance(transform.position, hit.point);
            desiredCamPosition = new Vector3(0, 0, -distance);
        }

        currentCamPosition = Vector3.Lerp(currentCamPosition, desiredCamPosition, Time.deltaTime * zoomSpeed);
        cameraTransform.localPosition = currentCamPosition;
    }

    private void HandleCameraRotation()
    {
        MouseVerticalValue = Input.GetAxis("Mouse Y") * sensitivity;
        Quaternion finalRotation = Quaternion.Euler(
            -MouseVerticalValue,
            0, 0);

        cameraTransform.localRotation = finalRotation;

        body.rotation = Quaternion.Euler(
            0,
            body.localRotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity,
            0);
    }

    private void HandleCursorLock()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
