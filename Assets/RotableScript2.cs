using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotableScript2 : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis;

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
            transform.Rotate(Vector3.up * (inverted ? 1 : -1), rotation.x, Space.World);
            transform.Rotate(cam.right * (inverted ? -1 : 1), rotation.y, Space.World);
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
