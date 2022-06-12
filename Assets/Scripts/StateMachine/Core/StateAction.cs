using StateMachine.ScriptableObjects;

namespace StateMachine.Core
{
    public abstract class StateAction : IStateComponent
    {
        internal StateActionSO originSO;

        protected StateActionSO OriginSO => originSO;

        public abstract void OnUpdate();

        public virtual void Awake(StateMachine stateMachine) { }

        public virtual void OnEnterState() { }

        public virtual void OnExitState() { }

        public enum SpecificMoment
        {
            OnEnterState, OnStateExit, OnUpdate,
        }
    }
}