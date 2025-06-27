using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotableScript2 : MonoBehaviour
{
    /*  [SerializeField] private InputAction pressed, axis;

      public float zoomSpeed = 1f;
      public float minScale = 1f;
      public float maxScale = 2.1f;
      private Transform cam;
      [SerializeField] private float speed = 1;
      [SerializeField] private bool inverted;
      private Vector2 rotation;
      private bool rotateAllowed;
      private void Awake()
      {
          cam = Camera.main.transform;
          pressed.Enable();
          axis.Enable();
          pressed.performed += _ => { StartCoroutine(Rotate()); };
          pressed.canceled += _ => { rotateAllowed = false; };
          axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
      }

      private IEnumerator Rotate()
      {
          rotateAllowed = true;
          while (rotateAllowed)
          {
              // apply rotation
              rotation *= speed;
              gameObject.transform.Rotate(Vector3.up * (inverted ? 1 : -1), rotation.x, Space.World);
              gameObject.transform.Rotate(cam.right * (inverted ? -1 : 1), rotation.y, Space.World);
              yield return null;
          }
      }

      private void Update()
      {
          float scrollInput = Input.GetAxis("Mouse ScrollWheel");
          if (scrollInput != 0)
          {
              // Calculate the new scale factor
              float scaleFactor = 1 + scrollInput * zoomSpeed;
              Vector3 newScale = gameObject.transform.localScale * scaleFactor;

              // Clamp the new scale to ensure it stays within the min and max limits
              newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
              newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
              newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

              // Apply the clamped scale
              gameObject.transform.localScale = newScale;
          }
      }*/

    [Header("Target Object (child of camera)")]
    public Transform targetObject;

    [Header("Rotation Settings")]
    public float rotationSpeed = 5f;

    [Header("Pan Settings")]
    public float panSpeed = 0.1f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 2f;
    public float minZoom = 1f;
    public float maxZoom = 10f;
    public float minScale = 1f;
    public float maxScale = 2.1f;
    private Camera cam;
    private Vector3 lastMousePos;

    void Start()
    {
        cam = Camera.main;
        if (targetObject == null)
        {
            Debug.LogWarning("Target Object not assigned.");
        }
    }

    void Update()
    {
        HandleRotation();
        HandlePan();
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            // Calculate the new scale factor
            float scaleFactor = 1 + scrollInput * zoomSpeed;
            Vector3 newScale = gameObject.transform.localScale * scaleFactor;

            // Clamp the new scale to ensure it stays within the min and max limits
            newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
            newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
            newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

            // Apply the clamped scale
            gameObject.transform.localScale = newScale;
        }
    }

    void HandleRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            float rotX = delta.y * rotationSpeed * Time.deltaTime;
            float rotY = -delta.x * rotationSpeed * Time.deltaTime;

            targetObject.Rotate(cam.transform.up, rotY, Space.World);
            targetObject.Rotate(cam.transform.right, rotX, Space.World);

            lastMousePos = Input.mousePosition;
        }
    }

    void HandlePan()
    {
        if (Input.GetMouseButtonDown(2) || (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0)))
        {
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(2) || (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0)))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            Vector3 move = cam.transform.right * delta.x * panSpeed * Time.deltaTime
                           + cam.transform.up * delta.y * panSpeed * Time.deltaTime;
            targetObject.position += move;
            lastMousePos = Input.mousePosition;
        }
    }


   /* void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            Vector3 direction = cam.transform.forward * scroll * zoomSpeed;
            Vector3 newPosition = targetObject.position + direction;

            float distance = Vector3.Distance(cam.transform.position, newPosition);
            if (distance > minZoom && distance < maxZoom)
            {
                targetObject.position = newPosition;
            }
        }
    }*/
}
