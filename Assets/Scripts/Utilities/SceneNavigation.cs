using Collectives.GlobalConstants;
using UnityEngine.SceneManagement;

namespace Collectives.Utilities
{
    public static class SceneNavigation
    {
        public static void GoToScene(EGameScenes _scene)
        {
            SceneManager.LoadScene((int)_scene);
        }

        public static void GoToHeistSuccessScene()
        {
            SceneManager.LoadScene((int)EGameScenes.HEIST_SUCCESS);
        }

        public static void GoToHeistFailScene()
        {
            SceneManager.LoadScene((int)EGameScenes.HEIST_FAIL);
        }
    }
}