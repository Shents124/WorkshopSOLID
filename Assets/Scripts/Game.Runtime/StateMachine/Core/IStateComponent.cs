namespace StateMachine.Core
{
    public interface IStateComponent
    {
        void OnEnterState();
        void OnExitState();
    }
}