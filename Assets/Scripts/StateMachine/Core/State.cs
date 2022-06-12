using StateMachine.ScriptableObjects;

namespace StateMachine.Core
{
    public class State
    {
        internal StateSO _originSO;
        internal StateMachine _stateMachine;
        internal StateTransition[] _transitions;
        internal StateAction[] _actions;
        
        internal State() {}

        public State(StateSO originSo, StateMachine stateMachine, StateTransition[] transitions, StateAction[] actions)
        {
            _originSO = originSo;
            _stateMachine = stateMachine;
            _transitions = transitions;
            _actions = actions;
        }

        public void OnStateEnter()
        {
            void OnStateEnter(IStateComponent[] comps)
            {
                for (int i = 0; i < comps.Length; i++)
                    comps[i].OnEnterState();
            }
            OnStateEnter(_transitions);
            OnStateEnter(_actions);
        }

        public void OnUpdate()
        {
            foreach (var action in _actions)
            {
                action.OnUpdate();
            }
        }

        public void OnStateExit()
        {
            void OnStateExit(IStateComponent[] comps)
            {
                foreach (var t in comps)
                    t.OnExitState();
            }
            OnStateExit(_transitions);
            OnStateExit(_actions);
        }

        public bool TryGetTransition(out State state)
        {
            state = null;
            foreach (var stateTransition in _transitions)
            {
                if(stateTransition.TryGetTransition(out state))
                    break;
            }
            
            foreach (var stateTransition in _transitions)
            {
                stateTransition.ClearConditionState();
            }

            return state != null;
        }
    }
}