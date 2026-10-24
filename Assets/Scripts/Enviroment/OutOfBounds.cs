using System;
using Player;
using UnityEngine;

namespace Enviroment
{
    public class OutOfBounds : MonoBehaviour
    {
        [SerializeField] private HealthManager _healthManager;
        [SerializeField] private Rigidbody2D _rb;
        private SpriteRenderer _limit;

        private void Awake()
        {
            _limit =  GetComponent<SpriteRenderer>();
            if (_limit == null)
            {
                Debug.LogWarning("No SpriteRenderer attached to " + gameObject.name);
            }
        }

        private void Update()
        {
            if(_limit == null) return;
            
            // Checks if player is in bounds
            if(_limit.bounds.min.x < _rb.position.x  && _limit.bounds.max.x > _rb.position.x &&
               _limit.bounds.min.y < _rb.position.y && _limit.bounds.max.y > _rb.position.y) return; 
            _healthManager.Kill(); // "Kills" the player if it is out of bounds 
        }
    }
}