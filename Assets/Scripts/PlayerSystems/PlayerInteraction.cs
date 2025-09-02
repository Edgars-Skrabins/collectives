using Collectives.Utilities;
using UnityEngine;

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
            m_playerCamera = m_player.GetCameraSystem().GetMainCamera();
        }

        private void CheckForInteractable()
        {
            Ray ray = new Ray(m_playerCamera.transform.position, m_playerCamera.transform.forward);
            RaycastHit[] hits = new RaycastHit[1];
            Physics.RaycastNonAlloc(ray, hits, m_interactionDistance, m_interactableLayer);

            if (hits[0].collider == null)
            {
                HandleInteractableNotInRange();
            }
            else
            {
                HandleInteractableInRange(hits);
            }
        }

        private void HandleInteractableInRange(RaycastHit[] _hits)
        {
            for (int i = 0; i < _hits.Length; i++)
            {
                if (_hits[i].collider.TryGetComponent(out Interactable interactable) && interactable != m_currentInteractable)
                {
                    m_currentInteractable = interactable;
                    m_currentInteractable.HandleInteractInRange(m_player);
                }
            }
        }

        private void HandleInteractableNotInRange()
        {
            m_currentInteractable?.HandleInteractNoLongerInRange(m_player);
            m_currentInteractable = null;
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

            GizmosUtility.DrawRay(
                m_playerCamera.transform.position,
                m_playerCamera.transform.forward,
                m_interactionDistance,
                gameObject.layer,
                Color.green
            );
        }
    }
#endif
}