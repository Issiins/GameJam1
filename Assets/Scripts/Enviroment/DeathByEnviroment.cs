using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Enviroment
{
    public class EnviromentDamage : MonoBehaviour
    {
        private Collider2D _col;
        private void Awake()
        {
            _col = GetComponent<Collider2D>();
            if (_col == null)
            {
                Debug.LogWarning("Enviroment has no Collider2D attached");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            var healthManager = collision.GetComponent<HealthManager>();
            if (healthManager == null) return;
            healthManager.Kill();
        }
    }
}