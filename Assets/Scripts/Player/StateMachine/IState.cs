namespace Player
{
    public interface IState
    {
        public void OnStateEnter();
        public void OnStateExit();
        public void OnStateUpdate();
        public void OnStateFixedUpdate();
    }
}