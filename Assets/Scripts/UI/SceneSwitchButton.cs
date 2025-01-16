using Collectives.Utilities.Constants;
using UnityEngine;

namespace Collectives.UI
{
    public class SceneSwitchButton : CustomButton
    {
        [SerializeField] private EGameScenes m_sceneToGoTo;

        public override void HandleOnClick()
        {
            base.HandleOnClick();
            GlobalUINavigation.GoToScene(m_sceneToGoTo);
        }
    }
}
