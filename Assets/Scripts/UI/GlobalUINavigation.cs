using Collectives.Utilities.Constants;
using UnityEngine.SceneManagement;

namespace Collectives.UI
{
    public static class GlobalUINavigation
    {
        public static void GoToScene(EGameScenes _scene)
        {
            SceneManager.LoadScene((int)_scene);
        }
    }
}
