using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class JumpState : IState
    {
        InputController _inputController;
        MovementController _movementController;
        Animator _animator;

        public JumpState(InputController inputController, MovementController movementController, Animator animator)
        {
            _inputController = inputController;
            _movementController = movementController;
            _animator = animator;
        }

        public void OnStateEnter()
        {
            _movementController.Jump();
        }

        public void OnStateExit()
        {
        }

        public void StateUpdate()
        {
            
        }

        public void StateFixedUpdate()
        {
            _movementController.Move(_inputController.Direction);
        }
    }
}