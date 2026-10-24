using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuButtons : MonoBehaviour
    {
        [SerializeField] private string _gameplaySceneName = "GameplayScene";

        public void LoadGameplayScene()
        {
            SceneManager.LoadScene(_gameplaySceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}