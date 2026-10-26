using System;
using UnityEngine;

namespace Player
{
    public class Grounded : MonoBehaviour
    {
        [SerializeField] private Transform _shootingSpot1;
        [SerializeField] private Transform _shootingSpot2;
        [SerializeField] private float _raycastDistance;
        private const string k_layerName = "Ground";
        private Vector2 _direction;
        private void Awake()
        {
            _direction = Vector2.down;
        }

        public bool IsGrounded()
        {
            var hit1 = ShootRayCast(_shootingSpot1);
            var hit2 = ShootRayCast(_shootingSpot2);
            return hit1.collider != null || hit2.collider != null;
        }

        private RaycastHit2D ShootRayCast(Transform fromSpot)
        {
            return Physics2D.Raycast(fromSpot.position, _direction, _raycastDistance, LayerMask.GetMask(k_layerName));
        }
    }
}