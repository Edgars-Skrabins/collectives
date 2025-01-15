using Collectives.Utilities.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Collectives
{
    public class HeistSuccessScreen : MonoBehaviour
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene((int)EGameScenes.MAIN_MENU);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
