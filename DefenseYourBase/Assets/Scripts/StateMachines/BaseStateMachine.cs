namespace StateMachines
{
    public abstract class BaseStateMachine
    {
        public abstract void Enter();
        public abstract void Update();
        public abstract void LateUpdate();
        public abstract void FixedUpdate();
        public abstract void Exit();
    }
}