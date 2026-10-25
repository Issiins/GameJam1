using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enviroment
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScene;
        [SerializeField] private byte numberOfLevels = 3; // Adjust how many levels exists
        [SerializeField] private byte _currentLevel = 1; // Current level scene
        private const string k_sceneName = "LevelScene_";
        private const string k_mainMenuSceneName = "MainMenuScene";
        private Coroutine _loadingSceneCoroutine;
        private StringBuilder sb = new();
        public void LoadScene()
        {
            sb.Clear();
            // Builds scene name
            sb.Append(k_sceneName).Append(_currentLevel);
            _loadingSceneCoroutine = StartCoroutine(LoadSceneAsyncCoroutine(sb.ToString()));
        }

        public void LoadNextLevel()
        {
            _currentLevel++;
            if (_currentLevel <= numberOfLevels)
            {
                LoadScene();
                return;
            }
            // Loads main menu scene when all levels completed
            LoadMainMenu();
        }

        public void LoadMainMenu()
        {
            _loadingSceneCoroutine = StartCoroutine(LoadSceneAsyncCoroutine(k_mainMenuSceneName));
        }
        private IEnumerator LoadSceneAsyncCoroutine(string sceneName){
            if(_loadingScene != null) 
                _loadingScene.SetActive(true);
            var operation = SceneManager.LoadSceneAsync(sceneName);
            if (operation == null)
            {
                Debug.LogWarning("Unable to load scene " + sceneName);
                yield break;
            }
            while (!operation.isDone)
            {
                yield return null;
            }
        }
        private void OnDisable()
        {
            if(_loadingSceneCoroutine == null) return; 
            StopCoroutine(_loadingSceneCoroutine);
        }
    }
}