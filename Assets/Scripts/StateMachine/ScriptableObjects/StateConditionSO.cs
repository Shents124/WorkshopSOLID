using System.Collections.Generic;
using StateMachine.Core;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    public abstract class StateConditionSO : ScriptableObject
    {
        internal StateCondition GetCondition(Core.StateMachine stateMachine, bool expectedResult,
            Dictionary<ScriptableObject, object> createdInstances)
        {
            if (createdInstances.TryGetValue(this, out var obj) == false)
            {
                var condition = CreateCondition();
                condition._originSO = this;
                createdInstances.Add(this,condition);
                condition.Awake(stateMachine);
                obj = condition;
            }
            return new StateCondition(stateMachine, (Condition)obj, expectedResult);
        }

        protected abstract Condition CreateCondition();
    }

    public abstract class StateConditionSO<T> : StateConditionSO where T : Condition, new()
    {
        protected override Condition CreateCondition()
        {
            return new T();
        }
    }
}