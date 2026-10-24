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
        }

        private void Update()
        {
            if(_limit == null) return;
            if(_limit.bounds.min.x < _rb.position.x  && _limit.bounds.max.x > _rb.position.x &&
               _limit.bounds.min.y < _rb.position.y && _limit.bounds.max.y > _rb.position.y) return;
            _healthManager.Kill();
        }
    }
}