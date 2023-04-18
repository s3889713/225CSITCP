using UnityEngine;

public class ControllerMovementV1 : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        transform.position += movement * speed * Time.deltaTime;
    }
}