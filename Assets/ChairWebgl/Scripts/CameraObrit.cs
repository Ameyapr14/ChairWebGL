using UnityEngine;
using UnityEngine.EventSystems;

public class CameraOrbit : MonoBehaviour
{
    /* public Transform target;          // Object to orbit around
     public float distance = 5.0f;     // Distance from the target
     public float xSpeed = 120.0f;     // Mouse horizontal speed
     public float ySpeed = 120.0f;     // Mouse vertical speed

     public float yMinLimit = -20f;    // Vertical angle limits
     public float yMaxLimit = 80f;

     private float x = 0.0f;           // Current horizontal angle
     private float y = 0.0f;           // Current vertical angle

     void Start()
     {
         Vector3 angles = transform.eulerAngles;
         x = angles.y;
         y = angles.x;

         // Optional: lock the cursor to the game window
        *//* Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;*//*
     }

     void Update()
     {
         if (target)
         {
             // Get mouse input
             x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
             y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

             // Clamp vertical rotation
             y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

             // Calculate rotation
             Quaternion rotation = Quaternion.Euler(y, x, 0);

             // Calculate position
             Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
             Vector3 position = rotation * negDistance + target.position;

             // Apply rotation and position
             transform.rotation = rotation;
             transform.position = position;
         }
     }*/

    public Transform target; // The target to follow
    public float rotationSpeed = 5.0f;
    public float zoomSpeed = 10.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 15.0f;
    public LayerMask zoomColliderMask;
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
        /*    float scrollInput = Input.GetAxis("Mouse ScrollWheel");
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
            }*/
        //   ******************************************************************************************

        /*  if (target == null) return;

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scrollInput) > 0.01f)
        {
            Vector3 direction = (transform.position - target.position).normalized;
            float distance = Vector3.Distance(transform.position, target.position);

            float newDistance = Mathf.Clamp(distance - scrollInput * zoomSpeed, minZoom, maxZoom);
            transform.position = target.position + direction * newDistance;
        }*/


        //   ******************************************************************************************

        if (target == null) return;

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scrollInput) > 0.01f)
        {
            Vector3 dir = (transform.position - target.position).normalized;
            float distance = Vector3.Distance(transform.position, target.position);

            // Cast a ray from target to camera
            Ray ray = new Ray(target.position, dir);
            float minZoomDistance = 0.5f; // fallback value

            if (Physics.Raycast(ray, out RaycastHit hit, distance + 5f, zoomColliderMask))
            {
                // Use hit distance as minimum zoom
                minZoomDistance = hit.distance + 0.2f; // small buffer
            }

            float newDistance = Mathf.Clamp(distance - scrollInput * zoomSpeed, minZoomDistance, maxZoom);
            transform.position = target.position + dir * newDistance;
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