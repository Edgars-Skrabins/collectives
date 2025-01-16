using UnityEngine;

namespace Collectives.UI
{
    public class UIElement_QuitButton : UIElement_CustomButton
    {
        public override void HandleOnClick()
        {
            base.HandleOnClick();
            Application.Quit();
        }
    }
}
