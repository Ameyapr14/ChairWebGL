using UnityEngine;

public class TransformController : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public float rotateSpeed = 100f;
    public float scaleSpeed = 0.01f;

    private Vector3 lastMousePos;

    void Update()
    {
        HandlePan();
        HandleRotate();
        HandleScale();
    }

    void HandlePan()
    {
        // Left mouse button drag to pan (move)
        if (Input.GetMouseButtonDown(0))
            lastMousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            Vector3 move = new Vector3(delta.x, delta.y, 0) * moveSpeed;
            transform.Translate(move, Space.World);
            lastMousePos = Input.mousePosition;
        }
    }

    void HandleRotate()
    {
        // Right mouse button drag to rotate
        if (Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            float rotY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, -rotX, Space.World);
            transform.Rotate(Vector3.right, rotY, Space.World);
        }
    }

    void HandleScale()
    {
        // Scroll wheel to scale
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 scale = transform.localScale;
            scale += Vector3.one * scroll * scaleSpeed;
            transform.localScale = Vector3.Max(scale, Vector3.one * 0.1f); // prevent scale below 0.1
        }
    }
}
