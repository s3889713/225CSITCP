using UnityEngine;

public class MinimapPositionV14 : MonoBehaviour
{
    public Transform objectToFollow;
    public float distanceAbove = 5f;
    public float yOffset = 0f;
    public float xOffset = 0f;
    public float zOffset = 0f;
    public float scaleMultiplier = 1f;
    public float zoomMultiplier = 1f;
    public Vector3 defaultPositionOffset = new Vector3(0f, 10f, 0f);

    private Camera minimapCamera;
    private bool isPositionLocked = false;
    private Vector3 lockedPosition;
    private float lockedObjectScale;

    private void Start()
    {
        minimapCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (objectToFollow != null)
        {
            float objectScale = objectToFollow.localScale.y * scaleMultiplier;
            float cameraDistance = (objectScale / 2f) / Mathf.Tan(Mathf.Deg2Rad * (minimapCamera.fieldOfView / 2f));

            Vector3 newPosition = objectToFollow.position + Vector3.up * distanceAbove;
            newPosition.y += yOffset * objectScale;
            newPosition.x += xOffset;
            newPosition.z += zOffset;

            if (isPositionLocked)
            {
                newPosition = lockedPosition;
            }
            else
            {
                newPosition += defaultPositionOffset;
            }

            transform.position = newPosition - minimapCamera.transform.forward * cameraDistance;

            float zoomFactor = isPositionLocked ? lockedObjectScale * zoomMultiplier : objectScale * zoomMultiplier;
            if (minimapCamera.orthographic)
            {
                minimapCamera.orthographicSize = zoomFactor;
            }
            else
            {
                minimapCamera.fieldOfView = zoomFactor;
            }
        }
    }

    public void LockCameraPosition()
    {
        isPositionLocked = true;
        lockedPosition = transform.position;
        lockedObjectScale = objectToFollow.localScale.y;
    }

    public void UnlockCameraPosition()
    {
        isPositionLocked = false;
    }
}
