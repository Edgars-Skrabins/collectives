using System;
using System.Collections.Generic;
using System.Linq;
using Collectives.PlayerSystems;
using UnityEngine;

namespace Collectives
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        public event Action OnInteractSuccess;
        public event Action OnInteractFailure;

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

        protected virtual void Interact()
        {
            OnInteractSuccess?.Invoke();
        }

        public virtual void HandleInteractInRange(Player _interactor)
        {
            // Check if player is actually allowed to interact.
            // If can interact m_playersThatCanInteract.Add(_interactor) enable possible interact highlights;
            // If cannot interact m_playersThatCanInteract.Remove(_interactor) enable impossible interact highlights;
        }

        public void HandleInteractNoLongerInRange(Player _interactor)
        {
            m_playersThatCanInteract.Remove(_interactor);
            DisablePossibleInteractHighlight();
            DisableImpossibleInteractHighlight();
        }


        private void EnablePossibleInteractHighlight()
        {
            DisableImpossibleInteractHighlight();
            m_interactPossibleHighlight.SetActive(true);
        }

        private void DisablePossibleInteractHighlight()
        {
            m_interactPossibleHighlight.SetActive(false);
        }

        private void EnableImpossibleInteractHighlight()
        {
            DisablePossibleInteractHighlight();
            m_interactImpossibleHighlight.SetActive(true);
        }

        private void DisableImpossibleInteractHighlight()
        {
            m_interactImpossibleHighlight.SetActive(false);
        }
    }
}
