using System;
using UnityEngine;

namespace Player
{
    public class Grounded : MonoBehaviour
    {
        [SerializeField] private float _raycastDistance;
        private const string k_layerName = "Ground";
        private Transform _originPoint;
        private Vector2 _direction;
        private void Awake()
        {
            _originPoint = transform;
            _direction = Vector2.down;
        }

        public bool IsGrounded()
        {
            var hit = Physics2D.Raycast(_originPoint.position, _direction, _raycastDistance, LayerMask.GetMask(k_layerName));
            return hit.collider != null;
        }
    }
}