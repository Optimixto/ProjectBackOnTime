using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(2f, 10f)]
    public float movementSpeed = 4.5f;

    [Range(2f, 5f)]
    public float dashDistance = 3f;

    [Range(2f, 8f)]
    public float frictionOnDash = 5;

    [Range(0.5f, 4f)]
    public float dashCoolDown = 1f;

    private CharacterController controller;
    private float gravity;
    private Vector3 velocity;
    private float dashCounter;
    private Vector3 drag;

    private PlayerInputActions inputAction;

    private Vector2 movementInput;

    public bool isDisabled = false;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.PlayerMovementControls.Moving.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputAction.PlayerMovementControls.Dash.performed += ctx => Dash();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        gravity = Physics.gravity.y;
        drag = new Vector3(frictionOnDash, 0, frictionOnDash);
        dashCounter = 0;
    }

    private void Update()
    {
        if (!isDisabled)
        {
            float h = movementInput.x;
            float v = movementInput.y;

            if (controller.isGrounded && velocity.y < 0)
                velocity.y = 0f;

            Vector3 inputDirection = new Vector3(h, 0f, v);

            controller.Move(inputDirection * Time.deltaTime * movementSpeed);

            if (!inputDirection.Equals(Vector3.zero))
                transform.forward = inputDirection;

            UpdateMovement();
        }
    }

    private void UpdateMovement()
    {
        velocity.y += gravity * Time.deltaTime;
        velocity.x /= 1 + drag.x * Time.deltaTime;
        velocity.y /= 1 + drag.y * Time.deltaTime;
        velocity.z /= 1 + drag.z * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        dashCounter -= Time.deltaTime;
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void Dash()
    {
        if(dashCounter > 0f)
            return;

        dashCounter = dashCoolDown;

        velocity += Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * drag.x + 1)) / -Time.deltaTime),
                     0,
                     (Mathf.Log(1f / (Time.deltaTime * drag.z + 1)) / -Time.deltaTime)));
    }
}