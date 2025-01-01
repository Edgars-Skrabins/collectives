using System;
using Collectives.PlayerSystems;

namespace Collectives
{
    public interface IInteractable
    {
        public event Action OnInteractSuccess;
        public event Action OnInteractFailure;

        public void AttemptInteract(Player _interactor);

        public void HandleInteractInRange(Player _interactor);
        public void HandleInteractNoLongerInRange(Player _interactor);
    }
}
