using UnityEngine;
using UnityEngine.Events;

namespace Collectives.UI
{
    public abstract class UICustomButton : MonoBehaviour
    {
        public UnityEvent OnClick;

        public virtual void HandleOnClick()
        {
            OnClick?.Invoke();
        }
    }
}
