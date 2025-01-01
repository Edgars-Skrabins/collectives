using Collectives.PlayerSystems;
using UnityEngine.Events;

namespace Collectives
{
    public interface IInteractable
    {
        public UnityEvent OnInteractSuccess {get;}
        public UnityEvent OnInteractFailure {get;}

        public void AttemptInteract(Player _interactor);

        public void HandleInteractInRange(Player _interactor);
        public void HandleInteractNoLongerInRange(Player _interactor);
    }
}
