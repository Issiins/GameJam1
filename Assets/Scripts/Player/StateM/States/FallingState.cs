using UnityEngine;

namespace Player.States
{
    public class FallingState : IState
    {
        InputController _inputController;
        MovementController _movementController;
        Animator _animator;

        public FallingState(InputController inputController, MovementController movementController, Animator animator)
        {
            _inputController = inputController;
            _movementController = movementController;
            _animator = animator;
        }

        public void OnStateEnter()
        {
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