using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class Player : Character
    {
        [SerializeField] private PlayerCamera m_cameraSystem;
        [SerializeField] private CharacterController m_controller;
        [SerializeField] private PlayerMovement m_movementSystem;
        [SerializeField] private PlayerStamina m_staminaSystem;
        [SerializeField] private PlayerGroundCheck m_groundCheck;
        [SerializeField] private PlayerCarry m_carry;

        public CharacterController GetCharacterController() { return m_controller; }
        public PlayerMovement GetPlayerMovement() { return m_movementSystem; }
        public PlayerStamina GetPlayerStamina() { return m_staminaSystem; }
        public PlayerGroundCheck GetPlayerGroundCheck() { return m_groundCheck; }
        public PlayerCamera GetCameraSystem() { return m_cameraSystem; }
        public PlayerCarry GetCarrySystem() { return m_carry; }
    }
}
