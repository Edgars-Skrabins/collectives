using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerGroundCheck))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float m_jumpHeight = 5f;
    [SerializeField] private float m_gravity = 10f;

    private PlayerGroundCheck m_groundCheck;
    private CharacterController m_controller;
    private Vector3 m_velocity;

    private void Start()
    {
        m_groundCheck = GetComponent<PlayerGroundCheck>();
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Jump(Input.GetButtonDown("Jump"));
    }

    private void Jump(bool _jumpInput)
    {
        ApplyGroundedForce();

        if (_jumpInput && m_groundCheck.IsGrounded())
        {
            DoJump();
        }

        ApplyGravity();

        // Move the controller with the calculated velocity
        m_controller.Move(m_velocity * Time.deltaTime);
    }

    private void DoJump()
    {
        // Calculate the initial jump velocity for the desired jump height
        m_velocity.y = Mathf.Sqrt(2f * m_jumpHeight * m_gravity);
    }

    private void ApplyGroundedForce()
    {
        if (m_groundCheck.IsGrounded() && m_velocity.y < 0)
        {
            // Slight negative value to keep the player grounded
            m_velocity.y = -2f;
        }
    }

    private void ApplyGravity()
    {
        // Apply gravity to the vertical velocity
        m_velocity.y -= m_gravity * Time.deltaTime;
    }
}
