using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 10;
    public PhysicalCC physicalCC;

    public Transform bodyRender;

    void Update()
    {
        if (physicalCC.isGround)
        {
            physicalCC.moveInput = Vector3.ClampMagnitude(transform.forward
                            * Input.GetAxis("Vertical")
                            + transform.right
                            * Input.GetAxis("Horizontal"), 1f) * speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                physicalCC.inertiaVelocity.y = 0f;
                physicalCC.inertiaVelocity.y += jumpHeight;
            }
        }
    }
}
