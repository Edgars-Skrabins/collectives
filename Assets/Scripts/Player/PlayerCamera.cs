using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Camera m_mainCamera;

        public Camera GetMainCamera() { return m_mainCamera; }
    }
}
