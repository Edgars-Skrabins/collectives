using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class Player : Character
    {
        [SerializeField] private PlayerCamera m_cameraSystem;
        [SerializeField] private CharacterController m_controller;
        [SerializeField] private PlayerStamina m_staminaSystem;
        [SerializeField] private PlayerGroundCheck m_groundCheck;

        public CharacterController GetCharacterController() { return m_controller; }
        public PlayerStamina GetPlayerStamina() { return m_staminaSystem; }
        public PlayerGroundCheck GetPlayerGroundCheck() { return m_groundCheck; }
        public PlayerCamera GetCameraSystem() { return m_cameraSystem; }
    }
}
