using System;
using UnityEngine;

namespace Player
{
    public class Grounded : MonoBehaviour
    {
        [SerializeField] private float _raycastDistance;
        private const string k_layerName = "Ground";
        private Vector2 _direction;
        private void Awake()
        {
            _direction = Vector2.down;
        }

        public bool IsGrounded()
        {
            var hit = Physics2D.Raycast(transform.position, _direction, _raycastDistance, LayerMask.GetMask(k_layerName));
            return hit.collider != null;
        }
    }
}