using UnityEngine;

public class StayInside: MonoBehaviour
{
    public Transform target; 
    public float padding = 1f; 

    private Camera mainCamera;
    private float cameraHalfWidth, cameraHalfHeight;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        mainCamera = Camera.main;
        target = this.transform;
    }

    void Update()
    {
        CalculateCameraBounds();

        if (target != null)
        {
            Vector3 targetPosition = target.position;

            float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }

    void CalculateCameraBounds()
    {
        if (mainCamera != null)
        {
            cameraHalfHeight = mainCamera.orthographicSize;
            cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;

            minX = mainCamera.transform.position.x - cameraHalfWidth + padding;
            maxX = mainCamera.transform.position.x + cameraHalfWidth - padding;
            minY = mainCamera.transform.position.y - cameraHalfHeight + padding;
            maxY = mainCamera.transform.position.y + cameraHalfHeight - padding;
        }
    }
}
