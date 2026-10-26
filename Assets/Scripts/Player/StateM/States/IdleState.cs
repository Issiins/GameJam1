using UnityEngine;

namespace Player.States
{
    public class IdleState : IState
    {
        private Animator _animator;

        public IdleState(Animator animator)
        {
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
        }
        private void SetAnimatorValues()
        {
            if(_animator == null) return;
            _animator.SetBool(AnimatorVariables.Grounded, true);
            _animator.SetFloat(AnimatorVariables.VelocityX, 0f);
        }
    }
}