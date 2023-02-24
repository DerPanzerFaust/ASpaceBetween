using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    
    public Transform playerBody;

    private float xRotation = 0f;

    private void Start()
    {
        // Cursor verdwijnt in het scherm
        // Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;

        // -90 graden is grens en +90 graden is grens
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // roteer vanuit eigen as
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
