using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target point (empty GameObject) to follow
    public float smoothSpeed = 5.0f; // Smoothing factor for camera movement
    public float zoomSpeed = 2.0f; // Speed at which the camera zooms in or out
    public float minZoom = 5.0f; // Minimum zoom level
    public float maxZoom = 10.0f; // Maximum zoom level

    private Vector3 offset; // Initial offset between camera and target
    private Camera mainCamera;

    private void Start()
    {
        offset = transform.position - target.position;
        mainCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Zoom functionality
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView - (scrollInput * zoomSpeed), minZoom, maxZoom);
    }
}