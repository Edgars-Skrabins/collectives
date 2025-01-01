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

        public void AttemptInteract(Player _interactor)
        {
            bool hasPlayersThatCanInteract = m_playersThatCanInteract.Any(player => player.GetID() == _interactor.GetID());

            if (hasPlayersThatCanInteract)
            {
                Interact();
            }
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }

        public void HandleInteractInRange(Player _interactor)
        {
            // Check if player is actually allowed to interact.
            m_playersThatCanInteract.Add(_interactor);
        }

        public void HandleInteractNoLongerInRange(Player _interactor)
        {
            m_playersThatCanInteract.Remove(_interactor);
            DisablePossibleInteractHighlight();
            DisableImpossibleInteractHighlight();
        }


        public void EnablePossibleInteractHighlight()
        {
            DisableImpossibleInteractHighlight();
            m_interactPossibleHighlight.SetActive(true);
        }

        public void DisablePossibleInteractHighlight()
        {
            m_interactPossibleHighlight.SetActive(false);
        }

        public void EnableImpossibleInteractHighlight()
        {
            DisablePossibleInteractHighlight();
            m_interactImpossibleHighlight.SetActive(true);
        }

        public void DisableImpossibleInteractHighlight()
        {
            m_interactImpossibleHighlight.SetActive(false);
        }
    }
}
