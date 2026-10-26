using DefaultNamespace;
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
            SetAnimatorValues();
            _movementController.Jump();
            SoundManager.Instance.PlayJumpSound();
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
            _animator.SetFloat(AnimatorVariables.VelocityY, 1f);
        }
    }
}