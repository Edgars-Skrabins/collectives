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
        [SerializeField] private Camera m_playerCamera;

        private Interactable m_currentInteractable;

        private void Update()
        {
            CheckForInteractable();
            HandleInteractionInput();
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
                }
            }
            else
            {
                m_currentInteractable = null;
            }
        }

        private void HandleInteractionInput()
        {
            if (m_currentInteractable != null && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F)))
            {
                m_currentInteractable.AttemptInteract(m_player);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            GizmosUtility.DrawRay(m_playerCamera.transform.position, m_playerCamera.transform.forward, m_interactionDistance, gameObject.layer, Color.green);
        }
    }
#endif
}
