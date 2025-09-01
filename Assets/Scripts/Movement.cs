using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement Settings")]
    public float walkSpeed = 10f;
    public float sprintSpeed = 15f;
    public float jumpForce = 8f;
    public float gravity = -20f;

    [Header("Sprint Settings")]
    public float sprintDuration = 3f;   // How long sprint lasts
    public float sprintCooldown = 2f;   // How long before sprint can be used again
    private float sprintTimer;
    private float cooldownTimer;
    private bool isSprinting;
    private bool sprintOnCooldown;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Weapon Bobbing")]
    public Transform leftSprite;
    public Transform rightSprite;
    public float bobSpeed = 6f;     // How fast they bob
    public float bobAmount = 0.05f; // How much they bob up and down

    private Vector3 leftSpriteInitialPos;
    private Vector3 rightSpriteInitialPos;
    private float bobTimer;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Movement Input
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        move.Normalize();

        float currentSpeed = walkSpeed;

        // Sprint logic
        if (Input.GetKey(KeyCode.LeftShift) && !sprintOnCooldown && sprintTimer < sprintDuration)
        {
            isSprinting = true;
            sprintTimer += Time.deltaTime;
            currentSpeed = sprintSpeed;

            if (sprintTimer >= sprintDuration)
            {
                sprintOnCooldown = true;
                cooldownTimer = 0f;
            }
        }
        else
        {
            isSprinting = false;
        }

        // Handle cooldown
        if (sprintOnCooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= sprintCooldown)
            {
                sprintOnCooldown = false;
                sprintTimer = 0f;
            }
        }

        // Move
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = jumpForce;

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
