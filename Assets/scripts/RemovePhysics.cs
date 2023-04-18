using UnityEngine;

public class RemovePhysics : MonoBehaviour
{
    void Start()
    {
        // Get the Rigidbody component of the player object
        Rigidbody rb = GetComponent<Rigidbody>();

        // Disable physics by setting isKinematic to true
        rb.isKinematic = true;
    }
}