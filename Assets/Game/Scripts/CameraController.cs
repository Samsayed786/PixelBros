using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public float maxVerticalAngle;
    public Transform body;
    private RaycastHit hit;
    private float _mouseVerticalValue;
    private Vector3 cam_offset;
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
            if (value == 0) return;

            float verticalAngle = _mouseVerticalValue + value;
            verticalAngle = Mathf.Clamp(verticalAngle, -maxVerticalAngle, 0);
            _mouseVerticalValue = verticalAngle;
        }
    }

    public float sensitivity;

    private void Start()
    {
        cam_offset = cameraTransform.localPosition;
        currentCamPosition = cam_offset;
    }

    void Update()
    {
        Vector3 desiredCamPosition = cam_offset;

        if (Physics.Linecast(transform.position, transform.position + transform.localRotation * cam_offset, out hit, obstacleLayers))
        {
            float distance = Vector3.Distance(transform.position, hit.point);
            desiredCamPosition = new Vector3(0, 0, -distance);
        }

        currentCamPosition = Vector3.Lerp(currentCamPosition, desiredCamPosition, Time.deltaTime * zoomSpeed);
        cameraTransform.localPosition = currentCamPosition;

        MouseVerticalValue = Input.GetAxis("Mouse Y");

        Quaternion finalRotation = Quaternion.Euler(
            -MouseVerticalValue * sensitivity,
            0, 0);

        cameraTransform.localRotation = finalRotation;

        body.rotation = Quaternion.Euler(
            0,
            body.localRotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity,
            0);

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
