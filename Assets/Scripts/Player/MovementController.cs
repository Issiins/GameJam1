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
        [SerializeField] private float jumpForce;

        private Rigidbody2D _rb;
        private Vector2 _direction;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputController.Move.performed += OnMove;
            _inputController.Move.canceled += OnMove;
            _inputController.Jump.performed += OnJump;
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            _direction = ctx.ReadValue<Vector2>();
            _rb.linearVelocityX = _direction.x  * _maxSpeed;
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            _rb.linearVelocityY = Vector2.up.y * jumpForce;
        }

        private void OnDisable()
        {
            _inputController.Move.performed -= OnMove;
            _inputController.Move.canceled -= OnMove;
            _inputController.Jump.performed -= OnJump;
        }
    }
}