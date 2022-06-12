using System.Collections.Generic;
using StateMachine.Core;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    public abstract class StateActionSO : ScriptableObject
    {
        internal StateAction GetAction(Core.StateMachine stateMachine,
            Dictionary<ScriptableObject, object> createdInstance)
        {
            if (createdInstance.TryGetValue(this, out var obj))
                return (StateAction)obj;

            var action = CreateAction();
            createdInstance.Add(this, action);
            action.originSO = this;
            action.Awake(stateMachine);
            return action;
        }

        protected abstract StateAction CreateAction();
    }

    public abstract class StateActionSO<T> : StateActionSO where T : StateAction, new()
    {
        protected override StateAction CreateAction()
        {
            return new T();
        }
    }
}