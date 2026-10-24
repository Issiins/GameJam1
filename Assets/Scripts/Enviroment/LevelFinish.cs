using System;
using Player;
using UnityEngine;

namespace Enviroment
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelFinish : MonoBehaviour
    {
        [SerializeField] private GameObject _levelFinishPanel;
        [SerializeField] private InputController _inputController;
        private float _cachedTimeScale;

        private void Awake()
        {
            _cachedTimeScale = Time.timeScale;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            if (_levelFinishPanel == null)
            {
                Debug.LogWarning("Level Finish Panel is missing");
                return;
            }
            Time.timeScale = 0f;
            _inputController.DisableInputs();
            _levelFinishPanel.SetActive(true);
        }

        private void OnDisable()
        {
            _inputController.EnableInputs();
            Time.timeScale = _cachedTimeScale;
        }
    }
}