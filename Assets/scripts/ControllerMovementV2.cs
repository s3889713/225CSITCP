using UnityEngine;

public class ControllerMovementV2 : MonoBehaviour
{
    public float speed = 1.0f;
    public float sensitivity = 1.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        transform.position += movement * speed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up, mouseX);
        Camera.main.transform.Rotate(Vector3.right, -mouseY);
    }
}