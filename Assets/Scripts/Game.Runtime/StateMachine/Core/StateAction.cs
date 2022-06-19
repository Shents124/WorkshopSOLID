using StateMachine.ScriptableObjects;

namespace StateMachine.Core
{
    public class StateAction : IStateComponent
    {
        internal StateActionSO originSO;

        protected StateActionSO OriginSO => originSO;

        public virtual void OnUpdate() { }
        
        public virtual void OnFixedUpdate() { }
        
        public virtual void Awake(StateMachine stateMachine) { }
        
        public virtual void OnEnterState() { }
        
        public virtual void OnExitState() { }
        
        public enum SpecificMoment
        {
            OnEnterState, OnStateExit, OnUpdate,
        }
    }
}