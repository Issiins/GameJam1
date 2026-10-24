using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;
        public Grounded Grounded { get; private set; }
        public Rigidbody2D RidigBody { get; private set; }
        private void Awake()
        {
            RidigBody = GetComponent<Rigidbody2D>();
            Grounded = GetComponentInChildren<Grounded>();
        }

        public void Move(Vector2 direction)
        {
            var deltaSpeed = direction.normalized.x > 0 ? _acceleration : _deceleration;
            var targetVelocity = _maxSpeed * direction.normalized.x;
            RidigBody.linearVelocityX = Mathf.MoveTowards(RidigBody.linearVelocityX, targetVelocity, Time.fixedDeltaTime * deltaSpeed);
        }
        public void Jump()
        {
            RidigBody.linearVelocityY = Vector2.up.y * _jumpForce;
        }
    }
}