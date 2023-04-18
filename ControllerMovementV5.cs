using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ControllerMovementV5 : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject objectToMove;

    private Vector3 movement;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalInput, 0, verticalInput);
    }

    private void FixedUpdate()
    {
        objectToMove.transform.Translate(movement * speed * Time.fixedDeltaTime, Space.Self);
    }
}