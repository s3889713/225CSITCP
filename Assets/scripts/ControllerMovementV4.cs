using UnityEngine;

public class ControllerMovementV4 : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform cameraTransform; // reference to the camera transform

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        transform.position += movement * speed * Time.deltaTime;

        // Rotate the camera transform only when the object is not moving
        if (movement == Vector3.zero)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            cameraTransform.RotateAround(transform.position, Vector3.up, mouseX);
            cameraTransform.RotateAround(transform.position, cameraTransform.right, -mouseY);
        }
    }
}