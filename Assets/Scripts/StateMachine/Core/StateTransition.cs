namespace StateMachine.Core
{
    public class StateTransition : IStateComponent
    {
        private State _targetState;
        private StateCondition[] _conditions;
        private int[] _resultGroups;
        private bool[] _results;

        internal StateTransition() { }

        public StateTransition(State targetState, StateCondition[] conditions, int[] resultsGroup = null)
        {
            Init(targetState, conditions, resultsGroup);
        }

        internal void Init(State targetState, StateCondition[] conditions, int[] resultGroups = null)
        {
            _targetState = targetState;
            _conditions = conditions;
            _resultGroups = resultGroups != null && resultGroups.Length > 0 ? resultGroups : new int [1];
            _results = new bool[_resultGroups.Length];
        }

        public bool TryGetTransition(out State state)
        {
            state = ShouldTransition() ? _targetState : null;
            return state != null;
        }
        
        public void OnEnterState()
        {
            foreach (StateCondition condition in _conditions)
            {
                condition._condition.OnEnterState();
            }
        }

        public void OnExitState()
        {
            foreach (StateCondition condition in _conditions)
            {
               condition._condition.OnExitState();
            }
        }
        
        private bool ShouldTransition()
        {
            int count = _resultGroups.Length;
            for (int i = 0, idx = 0; i < count && idx < _conditions.Length; i++)
                for (int j = 0; j < _resultGroups[i]; j++, idx++)
                    _results[i] = j == 0 ? _conditions[idx].IsMet() : _results[i] && _conditions[idx].IsMet();

            bool ret = false;
            for (int i = 0; i < count && !ret; i++)
                ret = _results[i];

            return ret;
        }

        internal void ClearConditionState()
        {
            foreach (var condition in _conditions)
            {
                condition._condition.ClearStatement();
            }
        }
    }
}