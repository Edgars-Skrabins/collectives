using System;
using Collectives.Utilities.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Collectives.UI
{
    public static class GlobalUINavigation
    {
        public static void GoToScene(EGameScenes _scene)
        {
            try
            {
                SceneManager.LoadScene((int)_scene);
            }
            catch (Exception exception)
            {
                Debug.LogError("Failed to load scene: " + _scene);
                throw;
            }
        }
    }
}
