using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;
        private Grounded _grounded;
        private Rigidbody2D _rb;
        private Vector2 _direction;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _grounded = GetComponentInChildren<Grounded>();
            SetActions();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            _direction = ctx.ReadValue<Vector2>();
        }
        private void FixedUpdate()
        {
            var deltaSpeed = _direction.normalized.x > 0 ? _acceleration : _deceleration;
            var targetVelocity = _maxSpeed * _direction.normalized.x;
            _rb.linearVelocityX = Mathf.MoveTowards(_rb.linearVelocityX, targetVelocity, Time.fixedDeltaTime * deltaSpeed);
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            if(_grounded == null ||  !_grounded.IsGrounded())
                return;
            _rb.linearVelocityY = Vector2.up.y * _jumpForce;
        }

        private void OnDisable()
        {
            DisableActions();
        }
        private void SetActions()
        {
            _inputController.Move.performed += OnMove;
            _inputController.Move.canceled += OnMove;
            _inputController.Jump.performed += OnJump;
        }
        private void DisableActions()
        {
            _inputController.Move.performed -= OnMove;
            _inputController.Move.canceled -= OnMove;
            _inputController.Jump.performed -= OnJump;
        }
    }
}