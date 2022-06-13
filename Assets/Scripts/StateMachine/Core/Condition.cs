using StateMachine.ScriptableObjects;

namespace StateMachine.Core
{
    public abstract class Condition : IStateComponent
    {
        private bool _isCached = false;
        private bool _cachedStatement = default;
        internal StateConditionSO _originSO;

        protected StateConditionSO OriginSO => _originSO;

        protected abstract bool Statement();

        internal bool GetStatement()
        {
            if (_isCached)
            {
                return _cachedStatement;
            }

            _isCached = true;
            _cachedStatement = Statement();

            return _cachedStatement;
        }

        internal void ClearStatement() => _isCached = false;

        public virtual void Awake(StateMachine stateMachine) { }

        public virtual void OnEnterState() { }

        public virtual void OnExitState() { }
    }

    public readonly struct StateCondition
    {
        internal readonly StateMachine _stateMachine;
        internal readonly Condition _condition;
        internal readonly bool _expectedResult;

        public StateCondition(StateMachine stateMachine, Condition condition, bool expectedResult)
        {
            _stateMachine = stateMachine;
            _condition = condition;
            _expectedResult = expectedResult;
        }

        public bool IsMet()
        {
            bool statement = _condition.GetStatement();
            var isMet = statement == _expectedResult;
            return isMet;
        }
    }
}