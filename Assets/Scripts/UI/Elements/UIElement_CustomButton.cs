using UnityEngine;
using UnityEngine.Events;

namespace Collectives.UI
{
    public abstract class UIElement_CustomButton : MonoBehaviour
    {
        public UnityEvent OnClick;

        public virtual void HandleOnClick()
        {
            OnClick?.Invoke();
        }
    }
}
