using System.Collections.Generic;
using StateMachine.Core;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New State", menuName = "State Machine/State")]
    public class StateSO : ScriptableObject
    {
        [SerializeField] private StateActionSO[] action = null;

        internal State GetState(Core.StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (createdInstances.TryGetValue(this, out var obj))
                return (State)obj;
            
            var state = new State();
            createdInstances.Add(this, state);

            state._originSO = this;
            state._stateMachine = stateMachine;
            state._transitions = new StateTransition[0];
            state._actions = GetActions(action, stateMachine, createdInstances);
            return state;
        }

        private static StateAction[] GetActions(StateActionSO[] scritableActions, Core.StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            int count = scritableActions.Length;
            var actions = new StateAction[count];
            for (int i = 0; i < count; i++)
                actions[i] = scritableActions[i].GetAction(stateMachine, createdInstances);
            return actions;
        }
    }
}