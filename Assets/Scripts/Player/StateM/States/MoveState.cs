using UnityEngine;

namespace Player.States
{
    public class MoveState : IState
    {
        InputController _inputController;
        MovementController _movementController;
        Animator _animator;
        public MoveState(InputController inputController, MovementController movement, Animator animator)
        {
            _inputController = inputController;
            _movementController = movement;
            _animator = animator;
        }

        public void OnStateEnter()
        { }

        public void OnStateExit() { }

        public void StateUpdate()
        {
            
        }

        public void StateFixedUpdate()
        {
            _movementController.Move(_inputController.Direction);
        }
    }
}