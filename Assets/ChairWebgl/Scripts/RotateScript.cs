using UnityEngine;
using UnityEngine.EventSystems;

public class RotateScript : MonoBehaviour
{
    /* private Vector3 lastMousePosition;
     public float zoomSpeed = 1f;
     public float minScale = 1f;
     public float maxScale = 2.1f;
     public float minX = -2f;
     public float maxX = 2f;
     public float minY = -10f;
     public float maxY = 10f;
     [SerializeField] public Rigidbody rb;


     void Update()
     {
         // Rotation
         if (Input.GetMouseButton(1)) // Right mouse button
         {
             float rotationSpeed = 100.0f;
             float horizontalInput = Input.GetAxis("Mouse X");
             float verticalInput = Input.GetAxis("Mouse Y");

             *//* transform.Rotate(Vector3.down, horizontalInput * rotationSpeed * Time.fixedDeltaTime);
              transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.fixedDeltaTime);*//*
             float x = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
             float y = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
             rb.AddTorque(Vector3.down * x);
             rb.AddTorque(Vector3.right * y);
         }

         // Zoom

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

         // Panning
         if (Input.GetMouseButtonDown(0)) // Left mouse button
         {
             lastMousePosition = Input.mousePosition;
         }

         if (Input.GetMouseButton(0)) // While holding left mouse button
         {
             Vector3 delta = lastMousePosition - Input.mousePosition;
             Vector3 move = new Vector3(delta.x, 0, 0) * Time.deltaTime;

             // Apply the movement and clamp the position to the defined boundaries
             Vector3 newPosition = transform.position + move;
             newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);


             transform.position = newPosition;

             lastMousePosition = Input.mousePosition;
         }
     }*/

/*    [SerializeField] private float rotateSpeed = 15;

    [SerializeField] private float xRotationThreshold = 30f;

    [SerializeField] private float mouseSensitivity = 12f;

    [SerializeField] public float touchSensitivity = 0.03f;

   [SerializeField] public Camera cam;*/

    public static bool canRotate;

    public float zoomSpeed = 1f;
    public float minScale = 1f;
    public float maxScale = 2.1f;

    private Vector3 lastMousePosition;

    Quaternion currentObjectRotation;
    Quaternion newRotation;

    public float minX = -2f;
    public float maxX = 2f;
    public float sensitivity = 5f;
    public float smoothSpeed = 5f;

    [Header("Pitch Limits")]
    public float minPitch = -80f;
    public float maxPitch = 80f;

    private float yaw = 0f, pitch = 0f;

    /*    private void Start()
        {

            canRotate = true;
            currentObjectRotation = transform.rotation;
            newRotation = transform.rotation;
        }
    */
    private void Update()
    {
        /* if (EventSystem.current.IsPointerOverGameObject() || !canRotate)
             return;*/

        /*   if (Input.GetMouseButtonDown(1)) // Left mouse button
           {
               lastMousePosition = Input.mousePosition;
           }

           if (Input.GetMouseButton(1)) // While holding left mouse button
           {
               Vector3 delta = lastMousePosition - Input.mousePosition;
               Vector3 move = new Vector3(delta.x, 0, 0) * Time.deltaTime;

               // Apply the movement and clamp the position to the defined boundaries
               Vector3 newPosition = transform.position + move;
               newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);


               transform.position = newPosition;

               lastMousePosition = Input.mousePosition;
           }*/

        /*  Vector3 right = Vector3.Cross(cam.transform.up, transform.position - cam.transform.position);
          if (Input.GetMouseButton(0) && Input.touchCount < 2)
          {
              // for touch
              float rotX = 0;
              float rotY = 0;
              float rotZ = 0;

              if (Input.touchCount == 1)
              {
                  rotX = Input.GetTouch(0).deltaPosition.x * mouseSensitivity * touchSensitivity;
              }
              else
              {
                  rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
              }

              newRotation = Quaternion.AngleAxis(-rotX, Vector3.up) * transform.localRotation;

              if (Input.touchCount == 1)
              {
                  rotY = Input.GetTouch(0).deltaPosition.y * mouseSensitivity * touchSensitivity;
              }
              else
              {
                  rotY = Input.GetAxis("Mouse Y") * mouseSensitivity;
              }


              newRotation = Quaternion.AngleAxis(rotY, right) * newRotation;
              newRotation = Quaternion.AngleAxis(rotY, Vector3.left) * newRotation;
          }

          var rotation = new Vector3(newRotation.eulerAngles.y, newRotation.eulerAngles.x, newRotation.z);

          var angle = rotation.y;
          angle %= 360;

          angle = angle > 180 ? angle - 360 : angle;

          if (angle > xRotationThreshold)
              rotation.y = xRotationThreshold;
          else if (angle < -xRotationThreshold)
              rotation.y = 360 - xRotationThreshold;

          newRotation = Quaternion.Euler(rotation.y, rotation.x, 0);

          currentObjectRotation = transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotateSpeed);*/


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

    }
}

