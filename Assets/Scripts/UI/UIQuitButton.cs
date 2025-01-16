using UnityEngine;

namespace Collectives.UI
{
    public class UIQuitButton : UICustomButton
    {
        public override void HandleOnClick()
        {
            base.HandleOnClick();
            Application.Quit();
        }
    }
}
