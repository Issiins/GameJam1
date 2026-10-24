using System;
using UnityEngine;

namespace Player
{
    public class HealthManager : MonoBehaviour
    {
        public event Action OnDeath;
        private DeathEvent _deathEvent;
        private bool _deathInvoked;
        private void Awake()
        {
            _deathEvent  = GetComponent<DeathEvent>();
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
            _deathEvent.OnDeath();
        }
    }
}