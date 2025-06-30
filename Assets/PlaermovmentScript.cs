using UnityEngine;

public class PlaermovmentScript : MonoBehaviour
{
    /*[Header("Mouse Look")]
    public Vector2 clampInDegrees = new Vector2(360, 180);
    public Vector2 sensitivity = new Vector2(2f, 2f);
    public Vector2 smoothing = new Vector2(3f, 3f);

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float shiftMultiplier = 2f;

    private Vector2 mouseAbsolute;
    private Vector2 smoothMouse;
    private Vector3 targetDirection;

    void Start()
    {
        targetDirection = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        // ———————————————————— Mouse Look ————————————————————
        if (Input.GetMouseButton(1)) // hold right-click to look around
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

            smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
            smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

            mouseAbsolute += smoothMouse;

           *//* if (clampInDegrees.x < 360) mouseAbsolute.x = Mathf.Clamp(mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);
            if (clampInDegrees.y < 360) mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);*//*

            transform.localRotation =
                             Quaternion.AngleAxis(-mouseAbsolute.y, transform.right) *
                              Quaternion.AngleAxis(mouseAbsolute.x, Vector3.up);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // ———————————————————— WASD Movement ————————————————————
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        bool running = Input.GetKey(KeyCode.LeftShift);
        transform.Translate(move * (moveSpeed * (running ? shiftMultiplier : 1f)) * Time.deltaTime, Space.World);
    }*/


    /* public float walkSpeed = 7.5f;
     public float runSpeed = 11.5f;
     public float jumpSpeed = 8f;
     public float gravity = 20f;

     public Camera playerCamera;
     public float lookSpeed = 2f;
     public float lookXLimit = 45f;

     private CharacterController cc;
     private Vector3 moveDir = Vector3.zero;
     private float rotationX = 0f;

     void Start()
     {
         cc = GetComponent<CharacterController>();
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
     }

     void Update()
     {
         // — Movement —
         Vector3 forward = transform.TransformDirection(Vector3.forward);
         Vector3 right = transform.TransformDirection(Vector3.right);
         bool isRun = Input.GetKey(KeyCode.LeftShift);

         float curSpeedX = (isRun ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
         float curSpeedY = (isRun ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
         float yVel = moveDir.y;

         moveDir = (forward * curSpeedX) + (right * curSpeedY);
         if (cc.isGrounded)
         {
             if (Input.GetButton("Jump"))
                 moveDir.y = jumpSpeed;
             else
                 moveDir.y = 0;
         }
         else moveDir.y = yVel - gravity * Time.deltaTime;

         cc.Move(moveDir * Time.deltaTime);

         // — Mouse Look —
         rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
         rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
         playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
         transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
     }*/



    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    public Vector3 externalMoveDirection;
    public bool useExternalMovement = false;

    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
       /* Cursor.lockState = CursorLockMode.Locked;*/
        //Cursor.visible = false;
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.R) && canMove)
            {
                characterController.height = crouchHeight;
                walkSpeed = crouchSpeed;
                runSpeed = crouchSpeed;

            }
            else
            {
                characterController.height = defaultHeight;
                walkSpeed = 6f;
                runSpeed = 12f;
            }

            characterController.Move(moveDirection * Time.deltaTime);
        }
        if (Input.GetMouseButton(1)) // hold right-click to look around
        {
            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }

    }

    /*if (useExternalMovement)
    {
        // Only apply external movement
        moveDirection = externalMoveDirection;
    }
    else
    {
        // Your existing input logic
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }
    }

    characterController.Move(moveDirection * Time.deltaTime);
}*/
}

