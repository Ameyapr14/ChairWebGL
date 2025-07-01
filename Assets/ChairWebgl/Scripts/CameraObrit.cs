using UnityEngine;
using UnityEngine.EventSystems;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The target to follow
    public float rotationSpeed = 5.0f;
    public float zoomSpeed = 10.0f;
    public float minScale = 5.0f;
    public float maxScale = 15.0f;
    private float currentZoom = 10.0f;

    private void Update()
    {
        // Rotate camera
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.RotateAround(target.position, Vector3.up, horizontal);
            transform.RotateAround(target.position, transform.right, vertical);
        }

        // Zoom camera
        /* float scroll = Input.GetAxis("Mouse ScrollWheel");
         if (scroll != 0.0f)
         {
             // Calculate the new position
             Vector3 newPosition = transform.position + transform.forward * scroll * zoomSpeed;

             // Clamp the position to prevent going too close or too far
             float distance = Vector3.Distance(newPosition, transform.position);
            *//* if (distance >= minDistance && distance <= maxDistance)
             {
                 transform.position = newPosition;
             }*//*
         }*/
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            // Calculate the new scale factor
            float scaleFactor = 1 + scrollInput * zoomSpeed;
            Vector3 newScale = transform.localScale * scaleFactor;

            // Clamp the new scale to ensure it stays within the min and max limits
            newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
            newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
            newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

            // Apply the clamped scale
            transform.localScale = newScale;
        }

        // Pan camera
        if (Input.GetMouseButton(2)) // Middle mouse button
        {
            float h = -Input.GetAxis("Mouse X") * zoomSpeed * Time.deltaTime;
            float v = -Input.GetAxis("Mouse Y") * zoomSpeed * Time.deltaTime;

            transform.Translate(new Vector3(h, v, 0));
        }
    }
}