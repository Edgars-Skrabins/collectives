using Collectives.Utilities;
using UnityEngine;

namespace Collectives.PlayerSystems

{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private Transform m_camera;
        [SerializeField] private Transform m_player;
        [Space]
        [SerializeField] private float m_mouseSensitivity;

        private float m_xRotation;

        private void Start()
        {
            CursorUtility.DisableCursor();
        }

        private void FixedUpdate()
        {
            HandleLookMechanics();
        }

        private void HandleLookMechanics()
        {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * m_mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * m_mouseSensitivity;

            m_xRotation -= mouseY;
            m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

            m_camera.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
            m_player.Rotate(Vector3.up * mouseX);
        }
    }
}