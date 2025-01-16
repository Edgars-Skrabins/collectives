using UnityEngine;
using UnityEngine.Events;

namespace Collectives.UI
{
    public abstract class CustomButton : MonoBehaviour
    {
        public UnityEvent OnClick;

        public virtual void HandleOnClick()
        {
            OnClick?.Invoke();
        }
    }
}
