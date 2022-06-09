using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    public Transform Orientation;

    float XRotation;
    float YRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Mouse Inputs - get
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;

        // Inputs invert, camera degree limit
        YRotation += mouseX;
        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        // Rotation and orientation

        transform.rotation = Quaternion.Euler(XRotation, YRotation, 0);

        Orientation.rotation = Quaternion.Euler(0, YRotation, 0);
    }
}