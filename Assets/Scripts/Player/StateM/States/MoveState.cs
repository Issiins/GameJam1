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
        {
            SetAnimatorValues();
        }

        public void OnStateExit() { }

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
            _animator.SetBool(AnimatorVariables.Grounded, true);
            _animator.SetFloat(AnimatorVariables.VelocityX, 1f);
        }
    }
}