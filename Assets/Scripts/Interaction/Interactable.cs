using System.Collections.Generic;
using System.Linq;
using Collectives.PlayerSystems;
using UnityEngine;
using UnityEngine.Events;

namespace Collectives
{
    public abstract class Interactable : MonoBehaviour
    {
        [Space(5)]
        [Header("Interaction settings")]
        [Space(5)]
        public UnityEvent OnInteractSuccess;
        public UnityEvent OnInteractFailure;

        [SerializeField] private GameObject m_interactPossibleHighlight;
        [SerializeField] private GameObject m_interactImpossibleHighlight;

        private readonly List<Player> m_playersThatCanInteract = new List<Player>();

        public virtual void AttemptInteract(Player _interactor)
        {
            bool hasPlayersThatCanInteract = m_playersThatCanInteract.Any(player => player.GetID() == _interactor.GetID());

            if (hasPlayersThatCanInteract)
            {
                Interact();
                return;
            }

            OnInteractFailure?.Invoke();
        }

        public virtual void HandleInteractInRange(Player _interactor)
        {
            // Check if player is actually allowed to interact.
            // If the player can interact m_playersThatCanInteract.Add(_interactor) enable possible interact highlights;
            // If the player cannot interact m_playersThatCanInteract.Remove(_interactor) enable impossible interact highlights;
            m_playersThatCanInteract.Add(_interactor);
        }

        public virtual void HandleInteractNoLongerInRange(Player _interactor)
        {
            m_playersThatCanInteract.Remove(_interactor);
            DisablePossibleInteractHighlight();
            DisableImpossibleInteractHighlight();
        }

        protected virtual void Interact()
        {
            OnInteractSuccess?.Invoke();
        }

        protected virtual void EnablePossibleInteractHighlight()
        {
            DisableImpossibleInteractHighlight();
            m_interactPossibleHighlight.SetActive(true);
        }

        protected virtual void DisablePossibleInteractHighlight()
        {
            m_interactPossibleHighlight.SetActive(false);
        }

        protected virtual void EnableImpossibleInteractHighlight()
        {
            DisablePossibleInteractHighlight();
            m_interactImpossibleHighlight.SetActive(true);
        }

        protected virtual void DisableImpossibleInteractHighlight()
        {
            m_interactImpossibleHighlight.SetActive(false);
        }
    }
}
