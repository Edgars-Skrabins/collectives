using System;
using Collectives.PlayerSystems;

namespace Collectives
{
    public interface IInteractable
    {
        public event Action OnInteractSuccess;
        public event Action OnInteractFailure;

        public void AttemptInteract(Player _interactor);
        public void Interact();
        public void HandleInteractInRange(Player _interactor);
        public void HandleInteractNoLongerInRange(Player _interactor);
        public void EnablePossibleInteractHighlight();
        public void DisablePossibleInteractHighlight();
        public void EnableImpossibleInteractHighlight();
        public void DisableImpossibleInteractHighlight();
    }
}
