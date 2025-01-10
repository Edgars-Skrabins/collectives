using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectives.Utilities;

namespace Collectives.PlayerSystems
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Player m_player;
        [SerializeField] private float m_interactionDistance;
        [SerializeField] private LayerMask m_interactableLayer;

        private Camera m_playerCamera;
#nullable enable
        private Interactable? m_currentInteractable;
#nullable disable

        private void Start()
        {
            InitializeCamera();
        }

        private void Update()
        {
            CheckForInteractable();
            HandleInteractionInput();
        }

        private void InitializeCamera()
        {
            m_playerCamera = m_player.Cameras.MainCamera;
        }

        private void CheckForInteractable()
        {
            Ray ray = new Ray(m_playerCamera.transform.position, m_playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, m_interactionDistance, m_interactableLayer))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null && interactable != m_currentInteractable)
                {
                    m_currentInteractable = interactable;
                    m_currentInteractable.HandleInteractInRange(m_player);
                }
            }
            else
            {
                m_currentInteractable?.HandleInteractNoLongerInRange(m_player);
                m_currentInteractable = null;
            }
        }

        private void HandleInteractionInput()
        {
            if (m_currentInteractable != null && Input.GetKeyDown(KeyCode.F))
            {
                m_currentInteractable.AttemptInteract(m_player);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!m_playerCamera) return;

            GizmosUtility.DrawRay(m_playerCamera.transform.position, m_playerCamera.transform.forward, m_interactionDistance, gameObject.layer, Color.green);
        }
    }
#endif
}
