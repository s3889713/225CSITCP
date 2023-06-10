using UnityEngine;

public class NameTagV4 : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 cameraPos = Camera.main.transform.position;

        Vector3 direction = cameraPos - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = rotation;

        transform.Rotate(0, 180, 0);
    }
}