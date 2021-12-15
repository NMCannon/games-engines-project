using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input for x axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // Get mouse input for y axis
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        // Clamp rotation before -90 and 90 degrees so player can't over-rotate
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate player on y axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotate player on x axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
