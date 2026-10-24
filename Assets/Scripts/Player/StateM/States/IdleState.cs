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
    }
}