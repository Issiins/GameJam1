using System;
using Player.States;
using UnityEngine;

namespace Player.StateM
{
    public class PlayerMovementStateMachine : StateMachine
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private MovementController _movementController;
        [SerializeField] private Animator _animator;
        IdleState _idleState;
        MoveState _moveState;
        JumpState _jumpState;
        FallingState _fallingState;

        private void Awake()
        {
            InitStates();
            _currentState = _idleState;
        }

        private new void Update()
        {
            base.Update();
            CheckTransitions();
        }

        private void InitStates()
        {
            _idleState = new IdleState(_animator);
            _moveState = new MoveState(_inputController, _movementController, _animator);
            _jumpState = new JumpState(_inputController, _movementController, _animator);
            _fallingState = new FallingState(_inputController, _movementController, _animator);
        }

        private void CheckTransitions()
        {
            bool isAgainstTheWall = _movementController.IsAgainstTheWall.IsAgainstTheWall();
            Debug.Log("Is againt the wall" + isAgainstTheWall);
            bool isGrounded = _movementController.Grounded.IsGrounded();
            Vector2 velocity = _movementController.RidigBody.linearVelocity;
            bool hasMoveInput = _inputController.Direction.x != 0f;
            bool jumpPressedThisFrame = _inputController.JumpAction.triggered;
            if ((isGrounded || isAgainstTheWall) && jumpPressedThisFrame)
            {
                ChangeState(_jumpState);
                return;
            }
            if (isGrounded && (_currentState == _idleState && hasMoveInput))
            {
                ChangeState(_moveState);
            }
            else if (isGrounded &&
                     (_currentState == _moveState && !hasMoveInput && Mathf.Approximately(velocity.x, 0f)))
            {
                ChangeState(_idleState);
            }
            else if (isGrounded)
            {
                if (_currentState == _fallingState || _currentState == _jumpState)
                {
                    ChangeState(hasMoveInput ? _moveState : _idleState);
                }
            }
            else
            {
                if (velocity.y < 0 && _currentState != _fallingState)
                {
                    ChangeState(_fallingState);
                }
            }
        }
    }
}