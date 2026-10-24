using UnityEngine;

namespace Player
{
    public class StateMachine : MonoBehaviour
    {
        protected IState _currentState { get; set; }
        
        protected void ChangeState(IState newState)
        {
            if (_currentState == null || _currentState.Equals(newState)) return;
            _currentState.OnStateExit();
            _currentState = newState;
            _currentState.OnStateEnter();
        }
        protected void Start()
        {
            _currentState?.OnStateEnter();
        }
        protected void Update()
        {
            _currentState?.StateUpdate();
        }
        protected void FixedUpdate()
        {
            _currentState?.StateFixedUpdate();
        }
    }
}