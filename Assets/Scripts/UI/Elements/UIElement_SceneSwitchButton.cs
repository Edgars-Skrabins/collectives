using Collectives.GlobalConstants;
using Collectives.Utilities;
using UnityEngine;

namespace Collectives.UI
{
    public class UIElement_SceneSwitchButton : UIElement_CustomButton
    {
        [SerializeField] private EGameScenes m_sceneToGoTo;

        public override void HandleOnClick()
        {
            base.HandleOnClick();
            SceneNavigation.GoToScene(m_sceneToGoTo);
        }
    }
}
