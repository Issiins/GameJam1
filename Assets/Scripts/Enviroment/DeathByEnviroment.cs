using System;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Enviroment
{
    [RequireComponent(typeof(Collider2D))]
    public class EnviromentDamage : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                if(tag.Equals("Projectile"))
                {
                    Destroy(gameObject);
                }
                return;
            }
            var healthManager = collision.GetComponent<HealthManager>();
            if (healthManager == null) return;
            healthManager.Kill();
        }
    }
}