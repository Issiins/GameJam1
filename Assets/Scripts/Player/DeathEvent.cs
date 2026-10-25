using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(HealthManager))]
    public class DeathEvent : MonoBehaviour
    {
        [SerializeField] private GameObject _deathPanel;
        [SerializeField] private InputController _inputController;
        public void OnDeath()
        {
            Time.timeScale = 0f;
            _deathPanel.SetActive(true);
            _inputController.DisableInputs();
        }
        private void OnDisable()
        {
            if(_inputController == null) return;
            _inputController.EnableInputs();
        }
    }
}