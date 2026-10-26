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
            SetAnimatorValues();
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

        private void SetAnimatorValues()
        {
            if(_animator == null) return;
            _animator.SetBool(AnimatorVariables.Grounded, false);
            _animator.SetFloat(AnimatorVariables.VelocityY, -1f);
        }
    }
}