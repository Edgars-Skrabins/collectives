using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class Player : Character
    {
        [SerializeField] private PlayerCamera m_cameraSystem;

        public PlayerCamera GetCameraSystem() { return m_cameraSystem; }
    }
}
