using System;
using DefaultNamespace;
using Player;
using UnityEngine;

namespace Enviroment
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelFinish : Interactable
    {
        [SerializeField] private GameObject _levelFinishPanel;
        [SerializeField] private InputController _inputController;
        [SerializeField] private Color _finsihedColor;
        private SpriteRenderer _spriteRenderer;
        private Color _baseColor;
        private float _cachedTimeScale;
        private bool _isCharacterInTrigger = false;
        private void Awake()
        {
            _cachedTimeScale = Time.timeScale;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            _isCharacterInTrigger = true;
            CheckAndTriggeredFinish();
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;

            _isCharacterInTrigger = false;
        }

        private void OnDisable()
        {
            _inputController.EnableInputs();
            Time.timeScale = _cachedTimeScale;
        }

        public override void Trigger(bool status)
        {
            base.Trigger(status);
            _spriteRenderer.color = status ? _finsihedColor : _baseColor;
            if (status)
            {
                CheckAndTriggeredFinish();
            }
        }

        private void CheckAndTriggeredFinish()
        {
            if (!Status || !_isCharacterInTrigger) return;
            if (_levelFinishPanel == null)
            {
                Debug.LogWarning("Level Finish Panel is missing");
                return;
            }
            if(SoundManager.Instance != null)
                SoundManager.Instance.PlayWinSound();
            Time.timeScale = 0f;
            _inputController.DisableInputs();
            _levelFinishPanel.SetActive(true);
        }
    }
}