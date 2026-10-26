using System;
using Player;
using UnityEngine;

namespace UI
{
    public class GamePausePanel : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private GameObject _pausePanel;
        
        private bool _isPaused;
        private float _cachedTimeScale = 1f;

        private void OnEnable()
        {
            _inputController.OnPauseTriggered += TogglePause;
        }

        private void OnDisable()
        {
            _inputController.OnPauseTriggered -= TogglePause;
        }

        private void Start()
        {
            if(_pausePanel == null) return;
            _pausePanel.SetActive(false);
        }

        private void TogglePause()
        {
            if (!_isPaused)
                PauseGame();
            else
                ResumeGame();
        }
        private void PauseGame()
        {
            _isPaused = true;
            _cachedTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            _pausePanel.SetActive(true);
            _inputController.DisablePlayerInputs();
        }
        private void ResumeGame()
        {
            _isPaused = false;
            Time.timeScale = _cachedTimeScale;
            _pausePanel.SetActive(false);
            _inputController.EnablePlayerInputs();
        }
    }
}