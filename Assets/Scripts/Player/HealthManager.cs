using System;
using UnityEngine;

namespace Player
{
    public class HealthManager : MonoBehaviour
    {
        public event Action OnDeath;
        private bool _deathInvoked;
        private void Awake()
        {
            OnDeath += Death;
        }
        private void OnDisable()
        {
            OnDeath -= Death;
        }

        public void Kill()
        {
            OnDeath?.Invoke();
        }

        private void Death()
        {
            if(_deathInvoked) return;
            _deathInvoked = true;
            Debug.Log($"{gameObject.name} is dead");
        }
    }
}