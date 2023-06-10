using UnityEngine;

public class ControllerMovementV7 : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("ControllerHorizontal");
        float moveVertical = Input.GetAxis("ControllerVertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }
}