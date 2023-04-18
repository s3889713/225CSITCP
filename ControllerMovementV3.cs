using UnityEngine;

public class ControllerMovementV3 : MonoBehaviour
{
    public float speed = 1.0f;

    private bool isMovingObject = false;

    void Update()
    {
        if (!isMovingObject)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

            transform.position += movement * speed * Time.deltaTime;
        }
    }

    public void SetIsMovingObject(bool value)
    {
        isMovingObject = value;
    }
}